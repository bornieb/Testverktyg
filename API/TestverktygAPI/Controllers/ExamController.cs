﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestverktygAPI.Data;
using TestverktygAPI.Models;

namespace TestverktygAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly TestverktygAPIContext _context;

        public ExamController(TestverktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/Exam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExam()
        {
            var result = await _context.Exam.Include(e => e.ExamQuestions)//Questionlista
            .ThenInclude(eq => eq.Question)//Question
            .Select(e => new
            {
            e.ExamId,
            e.ClassId,
            e.ExamDate,
            e.ExamTimeSpan,
            e.Subject,
            e.TotalPoints,
            e.GradeScale,
            e.CurrentQuestion,
            e.ExamResult,
            e.ExamStatus,
            e.ExamType,
            question = e.ExamQuestions.Select
            (eq => new
            {
                eq.Question.QuestionId,
                eq.Question.CourseId,
                eq.Question.GradeLevel,
                eq.Question.QuestionText,
                eq.Question.QuestionType,
                //eq.Question.QuestionValue,
                eq.Question.StudentsFreeAnswer,
            }
            )
            }).ToListAsync();

            return Ok(result);
            //return await _context.Exam.ToListAsync();
        }

        [HttpGet("student/{studentId}/{status}")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetStudentExams(int studentId, ExamStatus status)
        {
            var student = await _context.Student.FindAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            var exams = await _context.Exam
                .Include(e => e.ExamQuestions)
                    .ThenInclude(eq => eq.Question)
                        .ThenInclude(q => q.Alternatives)
                .Include(e => e.ExamQuestions)
                    .ThenInclude(eq => eq.Question)
                        .ThenInclude(q => q.Keywords)
                .Where(e => e.ClassId == student.ClassId && e.ExamStatus == status)
                .ToListAsync();

            foreach(var exam in exams)
            {
                exam.Questions = exam.ExamQuestions.Select(eq => eq.Question).ToList();

                foreach (var alt in exam.Questions)
                {
                    alt.Alternatives.ToList();
                }
                exam.ExamQuestions.Clear();
            }

            

            return exams;

            //var result = await _context.Exam.Include(e => e.ExamQuestions)
            //    .ThenInclude(eq => eq.Question)
            //    .Select()
        }

        ////Glenn, Teacher get NotTaken exams
        //[HttpGet("{classId}/{status}")]
        //public async Task<ActionResult<IEnumerable<Exam>>> GetNotTakenExams(int classId, ExamStatus status)
        //{
        //    var exams = await _context.Exam
        //        .Include(e => e.ExamQuestions)
        //            .ThenInclude(eq => eq.Question)
        //                .ThenInclude(q => q.Alternatives)
        //        .Include(e => e.ExamQuestions)
        //            .ThenInclude(eq => eq.Question)
        //                .ThenInclude(q => q.Keywords)
        //        .Where(e => e.ClassId == classId && e.ExamStatus == status)
        //        .ToListAsync();

        //    foreach (var exam in exams)
        //    {
        //        exam.Questions = exam.ExamQuestions.Select(eq => eq.Question).ToList();

        //        foreach (var alt in exam.Questions)
        //        {
        //            alt.Alternatives.ToList();
        //        }
        //        exam.ExamQuestions.Clear();
        //    }

        //    return exams;
        //}

        [HttpGet("{classId}/{status}")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetTakenExams(int classId, ExamStatus status)
        {
            var exams = await _context.Exam
                .Include(e => e.ExamQuestions)
                    .ThenInclude(eq => eq.Question)
                        .ThenInclude(q => q.Alternatives)
                .Include(e => e.ExamQuestions)
                    .ThenInclude(eq => eq.Question)
                        .ThenInclude(q => q.Keywords)
                .Where(e => e.ClassId == classId && e.ExamStatus == status)
                .ToListAsync();

            foreach (var exam in exams)
            {
                exam.Questions = exam.ExamQuestions.Select(eq => eq.Question).ToList();

                foreach (var alt in exam.Questions)
                {
                    alt.Alternatives.ToList();
                }
                exam.ExamQuestions.Clear();
            }

            return exams;
        }


        // GET: api/Exam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exam/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.ExamId)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Exam
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("userexam/{userId}")]
        public async Task<ActionResult<Exam>> PostExam(Exam exam, int userId)
        {
            var userExam = new UserExam() { Exam = exam, UserId = userId };
            var examQuestions = exam.Questions
                .Select(q => new ExamQuestion
                {
                    QuestionId = q.QuestionId,
                    Exam = exam
                }).ToList();
            exam.Questions.Clear();
            _context.UserExam.Add(userExam);
            _context.ExamQuestion.AddRange(examQuestions);
            _context.Exam.Add(exam);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.ExamId }, exam);

        }


        // DELETE: api/Exam/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exam>> DeleteExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();

            return exam;
        }

        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.ExamId == id);
        }
    }
}
