using Business_Layer;
using Moq;
using Data_Layer;
using Shared.Models;
using Data_Layer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Interfaces;

namespace StudentBusinessTest
{
    [TestClass]
    public class UnitTest1
    {

        private Mock<IStudentRepository> mockItemRepository = new Mock<IStudentRepository>();
        private Student student = new Student
        {
            Broj_Indexa = "153/2001",
            Ime = "John",
            Prezime = "Doe"
        };

        private List<Student> listOfItems = new List<Student>();
        private StudentBusiness studentbiz;

        public UnitTest1()
        {
            listOfItems.Add(student);
            listOfItems.Add(new Student
            {
                Broj_Indexa = "11/2001",
                Ime = "Jsohn",
                Prezime = "Dsoe"
            });
            listOfItems.Add(new Student
            {
                Broj_Indexa = "121/2001",
                Ime = "Josshn",
                Prezime = "Dssoe"
            });
        }



        [TestMethod]
        public void CreateStudent()
        {
            // Arrange
            mockItemRepository.Setup(x => x.CreateStudent(student)).Returns(1);
            this.studentbiz = new StudentBusiness(mockItemRepository.Object);

            // Act

            var result = studentbiz.AddStudent(student);

            // Assert

            Assert.AreEqual(result, 6);
        }


        [TestMethod]
        public void DeleteStudenta()
        {
            // Arrange
            mockItemRepository.Setup(x => x.DeleteStudent(student)).Returns(1);
            this.studentbiz = new StudentBusiness(mockItemRepository.Object);

            // Act
            var result = studentbiz.DeleteStudent(student);

            // Assert
            Assert.AreEqual(result, 5);
        }
        [TestMethod]
        public void UpdateStudent()
        {
            // Arrange
            mockItemRepository.Setup(x => x.UpdateStudent(student)).Returns(1);
            this.studentbiz = new StudentBusiness(mockItemRepository.Object);

            // Act
            var result = studentbiz.UpdateStudent(student);

            // Assert
            Assert.AreEqual(result, 5);
        }
        [TestMethod]
        public void GetPredmets_ShouldReturnList()
        {
            // Arrange
            var expectedStudents = new List<Student>
            {
            new Student {   },
        };
        
            mockItemRepository.Setup(x => x.GetStudents()).Returns(expectedStudents);

            this.studentbiz = new StudentBusiness(mockItemRepository.Object);

            // Act
            var result = studentbiz.GetStudents();

            // Assert
            CollectionAssert.AreEqual(result, expectedStudents);
        }
        [TestClass]
        public class UnitTest2
        {

            private Mock<IPredmetRepository> mockPredmetRepository = new Mock<IPredmetRepository>();
            private Predmet predmet = new Predmet
            {
                Id = 27,
                Naziv_Predmeta = "Matematika12",
                Broj_Studenta = 1
            };

            private List<Predmet> listOfItems = new List<Predmet>();
            private PredmetBusiness predmetbiz;

            public UnitTest2()
            {
                listOfItems.Add(predmet);
                listOfItems.Add(new Predmet
                {
                    Id = 28,
                    Naziv_Predmeta = "Matematika14",
                    Broj_Studenta = 2
                });
                listOfItems.Add(new Predmet
                {
                    Id = 29,
                    Naziv_Predmeta = "Matematika13",
                    Broj_Studenta = 3
                });

            }
            [TestMethod]
            public void CreatePredmets()
            {
                // Arrange
                mockPredmetRepository.Setup(x => x.CreatePredmet(predmet)).Returns(1);
                this.predmetbiz = new PredmetBusiness(mockPredmetRepository.Object);

                // Act

                var result = predmetbiz.CreatePredmet(predmet);

                // Assert

                Assert.AreEqual(result, 5);
            }


            [TestMethod]
            public void DeletePredmet()
            {
                // Arrange
                mockPredmetRepository.Setup(x => x.DeletePredmet(predmet)).Returns(1);
                this.predmetbiz = new PredmetBusiness(mockPredmetRepository.Object);

                // Act
                var result = predmetbiz.DeletePredmet(predmet);

                // Assert
                Assert.AreEqual(result, 5);
            }
            [TestMethod]
            public void UpdatePredmet()
            {
                // Arrange
                mockPredmetRepository.Setup(x => x.UpdatePredmet(predmet)).Returns(1);
                this.predmetbiz = new PredmetBusiness(mockPredmetRepository.Object);

                // Act
                var result = predmetbiz.UpdatePredmet(predmet);

                // Assert
                Assert.AreEqual(result, 5);
            }
            [TestMethod]
            public void GetUkupno_()
            {
                // Arrange
                var expectedValue=45;
               
                mockPredmetRepository.Setup(x => x.GetUkupno(It.IsAny<string>())).Returns(expectedValue);
                this.predmetbiz = new PredmetBusiness(mockPredmetRepository.Object);

                // Act
                var result = predmetbiz.Ukupno("PMA");

                // Assert
                Assert.AreEqual(result, expectedValue);
            }
            
            [TestMethod]
            public void GetPredmets_ShouldReturnList()
            {
                // Arrange
                var expectedPredmets = new List<Shared.Models.Predmet>
                     {
        new Shared.Models.Predmet {  },
       
                      };
                mockPredmetRepository.Setup(x => x.GetPredmets()).Returns(expectedPredmets);

                this.predmetbiz = new PredmetBusiness(mockPredmetRepository.Object);

                // Act
                var result = predmetbiz.GetPredmets();

                // Assert
                CollectionAssert.AreEqual(result, expectedPredmets);
            }


        }
        [TestClass]
        public class UpisanPredmetBusinessTests
        {
            [TestMethod]
            public void GetUpisanPredmets_ShouldReturnList()
            {
                // Arrange
                var expectedUpisani = new List<UpisanPredmet> {  };
                var mockUpisaniPredmetRepository = new Mock<IUpisaniPredmetiRepository>();
                mockUpisaniPredmetRepository.Setup(x => x.GetUpisanPredmets()).Returns(expectedUpisani);

                var upisanPredmetBusiness = new UpisanPredmetBusiness(mockUpisaniPredmetRepository.Object);

                // Act
                var result = upisanPredmetBusiness.GetUpisanPredmets();

                // Assert
                CollectionAssert.AreEqual(expectedUpisani, result);
            }

            [TestMethod]
            public void GetUpisane_ShouldReturnListBasedOnParameter()
            {
                // Arrange
                var expectedUpisani = new List<UpisanPredmet> {  };
                var mockUpisaniPredmetRepository = new Mock<IUpisaniPredmetiRepository>();
                mockUpisaniPredmetRepository.Setup(x => x.GetUpisane(It.IsAny<string>())).Returns(expectedUpisani);

                var upisanPredmetBusiness = new UpisanPredmetBusiness(mockUpisaniPredmetRepository.Object);

                // Act
                var result = upisanPredmetBusiness.GetUpisane("yourParameter");

                // Assert
                CollectionAssert.AreEqual(expectedUpisani, result);
            }
        }
        [TestClass]
        public class UcionicaBusinessTests
        {
            [TestMethod]
            public void GetUcionicas_ShouldReturnList()
            {
                // Arrange
                var expectedUcionice = new List<Ucionica> {  };
                var mockUcionicaRepository = new Mock<IUcionicaRepository>();
                mockUcionicaRepository.Setup(x => x.GetUcionicas()).Returns(expectedUcionice);

                var ucionicaBusiness = new UcionicaBusiness(mockUcionicaRepository.Object);

                // Act
                var result = ucionicaBusiness.GetUcionicas();

                // Assert
                CollectionAssert.AreEqual(expectedUcionice, result);
            }

            [TestMethod]
            public void GetTips_ShouldReturnListBasedOnParameter()
            {
                // Arrange
                var expectedUcionice = new List<Ucionica> {  };
                var mockUcionicaRepository = new Mock<IUcionicaRepository>();
                mockUcionicaRepository.Setup(x => x.GetTips(It.IsAny<string>())).Returns(expectedUcionice);

                var ucionicaBusiness = new UcionicaBusiness(mockUcionicaRepository.Object);

                // Act
                var result = ucionicaBusiness.GetTips("Mora String");

                // Assert
                CollectionAssert.AreEqual(expectedUcionice, result);
            }
        }
    }
}
