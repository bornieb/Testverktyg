using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestverktygAPI.Data;
using TestverktygAPI.Models;

namespace TestverktygAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly TestverktygAPIContext _context;

        public QuestionController(TestverktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            return await _context.Question.ToListAsync();
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Question.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // GET: api/Question/ExamId
        [HttpGet("e/{ExamId}")]
        public async Task<ActionResult<Question>> GetExamQuestion(int examId)
        {
            //var result = await _context.Exam.Include(q => q.Questions)//Questionslista
            //   .Select(q => new
            //   {
            //       q.ExamId,
            //       question = q.Questions.Select
            //        (qn => new
            //        {
            //            qn.QuestionId,
            //            qn.CourseId,
            //            qn.GradeLevel,
            //            qn.QuestionText,
            //            qn.QuestionType,
            //            qn.QuestionValue,
            //            qn.StudentsFreeAnswer

            //        })
            //   }).Where(x => x.ExamId == examId).FirstOrDefaultAsync();

            //return Ok(result);

            var result = await _context.Exam.Include(eq => eq.ExamQuestions)//Questionslista
              .Select(eq => new
              {
                  eq.ExamId,
                  question = eq.Questions.Select
                   (qn => new
                   {
                       qn.QuestionId,
                       qn.CourseId,
                       qn.GradeLevel,
                       qn.QuestionText,
                       qn.QuestionType,
                       qn.QuestionValue,
                       qn.StudentsFreeAnswer

                   })
              }).Where(x => x.ExamId == examId).FirstOrDefaultAsync();

            return Ok(result);
        }

        // PUT: api/Question/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Question
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            _context.Question.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Question.Remove(question);
            await _context.SaveChangesAsync();

            return question;
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }
    }
}
