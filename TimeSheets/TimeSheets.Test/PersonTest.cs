using Microsoft.AspNetCore.Mvc;
using Moq;
using TimeSheets.BL.Repositories;
using TimeSheets.Controllers;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.PersonValidation;
using Xunit;

namespace TimeSheets.Test
{
    public class PersonTest
    {    
        private readonly ICreatePersonValidator _personValidator;
        private readonly IDeletePersonValidator _deleteValidator;
       
        [Fact]
        public async void Get_All_Test_Return_NotNull()
        {           
            var person = new Mock<IPersonRepository>();
            person.Setup(rp => rp.Get()).ReturnsAsync(GetTestPerson);
            var controller = new  PersonControllers(person.Object, _personValidator, _deleteValidator);           
            Assert.NotNull(controller);         
        }
        private List<Person> GetTestPerson()
        {
            var person = new List<Person>
            {
                new Person{Id = 1,FirstName ="Марк",LastName="Денисенко",Email = "123@.ru",Age = 9,Company = "123",IsDelete = false}
            };
            return person;
        }
    }
}