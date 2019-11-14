using AutoMapper;
using Business.Models;
using Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using coreEntityFramework;
using Dal.Entities;
using Business;

namespace UnitTestOnline.Business.Services
{
    [TestClass]
    public class CandidatesServiceTest
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates_In_CandidateService()
        {
            var candidates = new List<CandidateDTO>()
            {
                new CandidateDTO ("camara", "minamba","c#",12),
                new CandidateDTO ("uzumaki", "naruto","python",14),
                new CandidateDTO ("uchiha", "sasuke",".net core",18)
            };

            var mockRepository = Substitute.For<ICandidatesRepository>();
            mockRepository.GetCandidatesAsync().Returns(candidates);
            var candidateService = new CandidatesService(mockRepository);

            var result = await candidateService.GetCandidatesAsync();
            string serialize1 = JsonConvert.SerializeObject(candidates);
            string serialize2 = JsonConvert.SerializeObject(result);

            Assert.AreEqual(serialize1, serialize2);
        }


        [TestMethod]
        public async Task Shoud_Get_Candidates_Result()
        {
            var results = new List<ResultModel>()
            {
                new ResultModel ("minamba","camara",1,1),
                new ResultModel ("minamba","camara",11,0),
                new ResultModel ("minamba","camara",22,1),
            };

            var mockRepository = Substitute.For<ICandidatesRepository>();
            mockRepository.GetResultsAsync().Returns(results);
            var candidateService = new CandidatesService(mockRepository);

            var result = await candidateService.GetResultsAsync();
            string serialize1 = JsonConvert.SerializeObject(results);
            string serialize2 = JsonConvert.SerializeObject(result);

            Assert.AreEqual(serialize1, serialize2);
        }


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
    }


    public class CandidatesEqual
    {

        public CandidateModel _CandidateModel { get; set; }

        public CandidatesEqual(CandidateModel cm)
        {
            _CandidateModel = cm;

        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var c = (CandidatesEqual)obj;
                return _CandidateModel == c._CandidateModel;
            }
        }

        public override int GetHashCode()
        {
            return -1271776452 + EqualityComparer<CandidateModel>.Default.GetHashCode(_CandidateModel);
        }
    }


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
}
