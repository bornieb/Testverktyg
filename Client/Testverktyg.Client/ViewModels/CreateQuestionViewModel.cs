using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.ViewModels
{
    public class CreateQuestionViewModel
    {
        public Question Question { get; set; }

        public CreateQuestionViewModel()
        {
            Question = new Question();
        }
    }
}
