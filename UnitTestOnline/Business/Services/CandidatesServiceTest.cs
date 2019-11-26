using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using Business.Services;
using TestOnline.Controllers;
using Business;
using Microsoft.AspNetCore.Mvc;
using TestOnline.Logs;

namespace UnitTestOnline.Business.Services
{
    [TestClass]
    public class CandidatesServiceTest
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates_In_CandidateService()
        {
            var candidates = GetCandidateModelFixture();
            var candidatesDTO = new List<CandidateDTO>();
            candidatesDTO = candidates.Select(d => new CandidateDTO(d.FirstName, d.LastName, d.Test.Title, 3)).ToList();

            var testModel = new List<TestModel>();
            testModel.Add(new TestModel("c#", 1, 10));
            testModel.Add(new TestModel("python", 2, 10));
            testModel.Add(new TestModel(".net core", 3, 10));

            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel(1, 1, "1", "a", 1));
            answers.Add(new AnswerModel(2, 2, "2", "b", 1));
            answers.Add(new AnswerModel(3, 3, "3", "c", 1));

            var mockRepository = Substitute.For<ICandidatesRepository>();
            var logger = Substitute.For<ILog>();
            mockRepository.GetCandidatesAsync().Returns(candidates);
            mockRepository.GetTestsAsync().Returns(testModel);
            mockRepository.GetAnswersAsync().Returns(answers);

            var candidateService = new CandidatesService(mockRepository, logger);
            var result = await candidateService.GetCandidatesAsync();

            string serialize1 = JsonConvert.SerializeObject(candidatesDTO);
            string serialize2 = JsonConvert.SerializeObject(result);

            Assert.AreEqual(serialize1, serialize2);
        }


        private List<global::Business.Models.Candidate> GetCandidateModelFixture() //QUAND LE CODE EST TROP LONG ON FAIT CE GENRE DE METHODE (règle de clean code)
        {
            var resultModel = new List<ResultModel>()
            {
                new ResultModel(1,true)
            };

            return new List<global::Business.Models.Candidate>()
            {
                new global::Business.Models.Candidate
                {
                    LastName = "camara",
                    FirstName = "minamba",
                    Test = new TestModel
                    {
                        Title = "C#"
                    },
                    Result = resultModel

                },
                new global::Business.Models.Candidate
                {
                    LastName = "uzumaki",
                    FirstName = "naruto",
                    Test = new TestModel
                    {
                        Title = "python"
                    },
                    Result = resultModel
                },
                new global::Business.Models.Candidate
                {
                    LastName = "uchiha",
                    FirstName = "sasuke",
                    Test = new TestModel
                    {
                        Title = ".net core"
                    },
                    Result = resultModel
                }
            };
        }

        [TestMethod]
        [DataRow(8)] // Un autre moyen de passer des paramètres pour les tests
        public async Task Shoud_Get_Average_In_CandidateService(double average)
        {
            var testModel = new List<TestModel>();
            testModel.Add(new TestModel("c#a", 1, 10));
            testModel.Add(new TestModel("c#b", 2, 10));
            testModel.Add(new TestModel("c#c", 3, 10));
            testModel.Add(new TestModel("c#d", 4, 10));

            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel(1, 1, "1", "a", 1));
            answers.Add(new AnswerModel(2, 2, "2", "b", 0));
            answers.Add(new AnswerModel(3, 3, "3", "c", 1));
            answers.Add(new AnswerModel(4, 4, "4", "d", 0));

            var results = new List<ResultModel>();
            results.Add(new ResultModel(1, true));
            results.Add(new ResultModel(2, false));
            results.Add(new ResultModel(3, true));
            results.Add(new ResultModel(4, false));

            var candidates = new List<Candidate>()
            {
                new Candidate("minamba","camara",testModel[0],results),
                new Candidate("naruto","uzumaki",testModel[1],results),
                new Candidate("sasuke","uchiha",testModel[2],results),
            };

            var mockRepository = Substitute.For<ICandidatesRepository>();
            var logger = Substitute.For<ILog>();
            mockRepository.GetCandidatesAsync().Returns(candidates);
            mockRepository.GetTestsAsync().Returns(testModel);
            mockRepository.GetAnswersAsync().Returns(answers);

            var candidateService = new CandidatesService(mockRepository,logger);
            double result = await candidateService.GetAverageAsync();


            Assert.AreEqual(average, result); // Pas beson de serialization car ce ne sont pas des types références (c'est à dire des objets) mais des types valeurs donc direct Assert.AreEqual
        }


        //TEST AVERAGE A 0
        [TestMethod] 
        public async Task Shoud_Get_Average_In_CandidateService_with_0_value()
        {
            var testModel = new List<TestModel>();
            testModel.Add(new TestModel("c#a", 1, 10));
            testModel.Add(new TestModel("c#b", 2, 10));
            testModel.Add(new TestModel("c#c", 3, 10));
            testModel.Add(new TestModel("c#d", 4, 10));

            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel(1, 1, "1", "a", 0));
            answers.Add(new AnswerModel(2, 2, "2", "b", 0));
            answers.Add(new AnswerModel(3, 3, "3", "c", 0));
            answers.Add(new AnswerModel(4, 4, "4", "d", 0));

            var results = new List<ResultModel>();
            results.Add(new ResultModel(1, false));
            results.Add(new ResultModel(2, false));
            results.Add(new ResultModel(3, false));
            results.Add(new ResultModel(4, false));

            var candidates = new List<Candidate>()
            {
                new Candidate("minamba","camara",testModel[0],results),
                new Candidate("naruto","uzumaki",testModel[1],results),
                new Candidate("sasuke","uchiha",testModel[2],results),
            };

            var mockRepository = Substitute.For<ICandidatesRepository>();
            var logger = Substitute.For<ILog>();
            mockRepository.GetCandidatesAsync().Returns(candidates);
            mockRepository.GetTestsAsync().Returns(testModel);
            mockRepository.GetAnswersAsync().Returns(answers);


            var candidateService = new CandidatesService(mockRepository, logger);


            await Assert.ThrowsExceptionAsync<Exception>(() => candidateService.GetAverageAsync());
        }


        //TEST AVERAGE A 0
        [TestMethod]
        public async Task Shoud_Get_Average_LOG_In_CandidateService_with_0_value()
        {
            var testModel = new List<TestModel>();
            testModel.Add(new TestModel("c#a", 1, 10));
            testModel.Add(new TestModel("c#b", 2, 10));
            testModel.Add(new TestModel("c#c", 3, 10));
            testModel.Add(new TestModel("c#d", 4, 10));

            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel(1, 1, "1", "a", 0));
            answers.Add(new AnswerModel(2, 2, "2", "b", 0));
            answers.Add(new AnswerModel(3, 3, "3", "c", 0));
            answers.Add(new AnswerModel(4, 4, "4", "d", 0));

            var results = new List<ResultModel>();
            results.Add(new ResultModel(1, false));
            results.Add(new ResultModel(2, false));
            results.Add(new ResultModel(3, false));
            results.Add(new ResultModel(4, false));

            var candidates = new List<Candidate>()
            {
                new Candidate("minamba","camara",testModel[0],results),
                new Candidate("naruto","uzumaki",testModel[1],results),
                new Candidate("sasuke","uchiha",testModel[2],results),
            };

            var mockRepository = Substitute.For<ICandidatesRepository>();
            var logger = Substitute.For<ILog>();
            mockRepository.GetCandidatesAsync().Returns(candidates);
            mockRepository.GetTestsAsync().Returns(testModel);
            mockRepository.GetAnswersAsync().Returns(answers);


            var candidateService = new CandidatesService(mockRepository, logger);


            logger.Received(1).Error(candidateService.GetAverageAsync().ToString());
        }


        [TestMethod]
        [DataRow(0)]
        public async Task Shoud_Get_EcartType_In_CandidateService(double ecartType)
        {
            var testModel = new List<TestModel>();
            testModel.Add(new TestModel("c#a", 1, 10));
            testModel.Add(new TestModel("c#b", 2, 10));
            testModel.Add(new TestModel("c#c", 3, 10));
            testModel.Add(new TestModel("c#d", 4, 10));

            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel(1, 1, "1", "a", 1));
            answers.Add(new AnswerModel(2, 2, "2", "b", 0));
            answers.Add(new AnswerModel(3, 3, "3", "c", 1));
            answers.Add(new AnswerModel(4, 4, "4", "d", 0));

            var results = new List<ResultModel>();
            results.Add(new ResultModel(1, true));
            results.Add(new ResultModel(2, false));
            results.Add(new ResultModel(3, true));
            results.Add(new ResultModel(4, false));

            var candidates = new List<Candidate>()
            {
                new Candidate("minamba","camara",testModel[0],results),
                new Candidate("naruto","uzumaki",testModel[1],results),
                new Candidate("sasuke","uchiha",testModel[2],results),
                new Candidate("madara","uchiha",testModel[3],results),

            };


            var mockRepository = Substitute.For<ICandidatesRepository>();
            var logger = Substitute.For<ILog>();
            mockRepository.GetCandidatesAsync().Returns(candidates);
            mockRepository.GetTestsAsync().Returns(testModel);
            mockRepository.GetAnswersAsync().Returns(answers);

            var candidateService = new CandidatesService(mockRepository,logger);
            double result = await candidateService.GetEcartTypeAsync();

            Assert.AreEqual(ecartType, result);
        }



        [TestMethod]
        public async Task Shoud_Add_CandidateTest_In_CandidateService()
        {
            var candidate = new Candidate()
            {
                FirstName = "Minamba",
                LastName = "Camara",
                Test = new TestModel()
                {
                    Title="c#"
                }
            };

            var mockRepository = Substitute.For<ICandidatesRepository>();
            var logger = Substitute.For<ILog>();
            mockRepository.AddCandidateTestAsync(candidate).Returns(candidate);
            var candidateService = new CandidatesService(mockRepository,logger);
            var result = await candidateService.AddCandidateTestAsync(candidate);

            Assert.AreEqual(candidate, result);
        }



        #region FakeTest
        [TestMethod]
        public void Example_test()
        {
            // Différence entre type valeur et type référence à l'initialisation
            int a1; // a1 = 0
            MyInteger myInteger1; // myInteger1 = null

            a1 = 5;
            int a2 = 5;
            myInteger1 = new MyInteger(5);
            var myInteger2 = new MyInteger(5);

            // Différence entre type valeur et type référence à la comparaison
            bool r1 = a1 == a2; // true
            bool r2 = a1.Equals(a2); // true
            // On compare des valeurs donc ça marche

            bool r3 = myInteger1 == myInteger2; // false
            bool r4 = myInteger1.Equals(myInteger2); // false
            // On compare des références (des pointeurs sur les véritables objets) donc ça ne marche pas

            //Assert.AreEqual(myInteger1, myInteger2); // false, comment faire ?

            // 4 solutions
            // 1) Comparer les propriétés une à une
            Assert.AreEqual(myInteger1.A, myInteger2.A);

            // 2) Sérializer les objets (les mettres sous forme de chaîne de caractères)
            string serialize1 = JsonConvert.SerializeObject(myInteger1); // {"A":5}
            string serialize2 = JsonConvert.SerializeObject(myInteger2); // {"A":5}
            Assert.AreEqual(serialize1, serialize2);

            // 3) Projeter des types anonymes dans le cas de liste
            var list1 = new List<MyInteger> { myInteger1 };
            var list2 = new List<MyInteger> { myInteger2 };
            CollectionAssert.AreEqual(list1.Select(m => new { m.A }).ToList(),
                                      list2.Select(m => new { m.A }).ToList());

            // 4) Redéfinir la méthode Equals dans la classe (on prend comme exemple MyIntegerWithEqual)
            var myInteger3 = new MyIntegerWithEqual(5);
            var myInteger4 = new MyIntegerWithEqual(5);
            Assert.AreEqual(myInteger3, myInteger4);


            // Petit test à la fin
            var myInteger5 = new MyInteger(3);
            var myInteger6 = myInteger5;
            Assert.AreEqual(myInteger5, myInteger6);
            myInteger6.A = 4;
            // myInteger5.A vaut 4
            // myInteger6.A vaut 4
        }
        #endregion
    }

    #region Fake clas
    //public class CandidatesEqual
    //{

    //    public Candidate _CandidateModel { get; set; }

    //    public CandidatesEqual(global::Business.Models.Candidate cm)
    //    {
    //        _CandidateModel = cm;

    //    }

    //    public override bool Equals(Object obj)
    //    {
    //        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            var c = (CandidatesEqual)obj;
    //            return _CandidateModel == c._CandidateModel;
    //        }
    //    }
    //    public override int GetHashCode()
    //    {
    //        return -1271776452 + EqualityComparer<global::Business.Models.Candidate>.Default.GetHashCode((global::Business.Models.Candidate)_CandidateModel);
    //    }
    //}
    public class MyInteger
    {
        public MyInteger(int a)
        {
            A = a;
        }

        public int A { get; set; }
    }

    public class MyIntegerWithEqual
    {
        public MyIntegerWithEqual(int a)
        {
            A = a;
        }

        public int A { get; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var p = (MyIntegerWithEqual)obj;
                return A == p.A;
            }
        }

        public override int GetHashCode()
        {
            return A;
        }
    }
    #endregion
}
