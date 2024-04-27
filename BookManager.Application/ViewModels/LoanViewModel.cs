using BookManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.ViewModels
{
    public class LoanViewModel
    {
        public int Id { get; private set; }
        public DateTime DateLoan { get; private set; }
        public LoanStatusEnum Status { get; private set; }

    }
}
