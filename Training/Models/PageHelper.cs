using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
            => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
    public partial class IndexViewModel
    {
        public IEnumerable<Training> Trainings { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}