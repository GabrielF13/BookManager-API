using BookManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.InputModels
{
    public class UpdateLoanInputModel
    {
        public int Id { get; private set; }
        
        public LoanStatusEnum Status { get; private set; }

        public int LoanDurationInDays { get; private set; }

    }
}
