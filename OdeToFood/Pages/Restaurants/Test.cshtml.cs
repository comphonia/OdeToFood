using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using System;

namespace OdeToFood.Pages.Restaurants
{

    public class Test2
    {
        public Guid Count { get; set; }

        public Test2(Test test)
        {
            Count = test.Counter;
        }
    }

    public class TestModel : PageModel
    {
        public string Message { get; set; }
        private Guid count;

        public TestModel(Test test)
        {
            count = test.GetGuid;
        }


        public void OnGet([FromServices] Test test)
        {


            Message = $"The counter is: {count} and {test.GetGuid}";
        }
    }
}
