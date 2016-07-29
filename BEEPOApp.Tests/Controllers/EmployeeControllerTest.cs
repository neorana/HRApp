using BEEPOApp.DAL;
using BEEPOApp.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BEEPOApp.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private readonly IUnitofWork _unitofWork;

        public EmployeeControllerTest()
        {
            var context = new HRISContext();
            _unitofWork = new UnitofWork(context);
        }

        [TestMethod]
        public void WillSaveChanges()
        {

            var mockContext = new Mock<HRISContext>();
            var unitOfWork = new UnitofWork(mockContext.Object);

            unitOfWork.Commit();

            //Assert
            mockContext.Verify(moq => moq.SaveChanges());
        }
        
        [TestMethod]
        public void GetAllEmployees()
        {

            //Assert
            Assert.IsNotNull(_unitofWork.Employee.GetEmployees());
        }

       
    }

   
}
