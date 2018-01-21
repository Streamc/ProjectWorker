using Proj_s.Models;
using System;
using System.Linq;

namespace Proj_s.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjectContext context)
        {
            context.Database.EnsureCreated();


            if (context.Workers.Any())
            {
                return;
            }
            var Workers = new Worker[]
                {
            new Worker{Firstname="Ivan", Lastname="Abercromb", Fathername="Vasilievich",email="Vasilievich41@mail.ru", Company_name="Chemistry"},
            new Worker{Firstname="Drago", Lastname="Petrov", Fathername="Bargovich",email="bargovich467@yandex.ru", Company_name="Fgery"},
            new Worker{Firstname="John", Lastname="Rambo", Fathername="First_Blood",email="Rocky@hh.ru", Company_name="Survive"},
            new Worker{Firstname="John", Lastname="Another", Fathername="Another",email="Another@hh.ru", Company_name="Another"},
            new Worker{Firstname="Superboss", Lastname="Leader", Fathername="Lead",email="boss@hh.ru", Company_name="dire"},
            new Worker{Firstname="Superboss1", Lastname="Leader1", Fathername="Lead1",email="boss1@hh.ru", Company_name="dire1"}
            // 1 23 105 107 4
                };

            foreach (Worker c in Workers)
            {
                context.Workers.Add(c);
            }
            context.SaveChanges();

            var Projects = new Project[]
            {
            new Project {
                //ID = 123,
                Name ="Carson",
                Customer_Company ="1stcustcom",
                Executive_Company ="1steeccom",
                ManagerID=5,
                Begin_date=DateTime.Parse("2011-09-01"),
                End_date=DateTime.Parse("2014-08-05"),
                Test_comment="Best comment" },
             new Project {
             //   ID = 1231,
                Name ="Stonebreaker",
                Customer_Company ="Embracodero",
                Executive_Company ="Litec",
                ManagerID=Workers.Single( i => i.Fathername == "First_Blood").ID,
                Begin_date=DateTime.Parse("2013-09-01"),
                End_date=DateTime.Parse("2014-08-05"),
                Priority=1,
                Test_comment="второй комментарий для удобства" },
             new Project {
                //ID = 456,
                Name ="Rules_adva",
                Customer_Company ="Embracodero",
                Executive_Company ="Foran",
                ManagerID=Workers.Single( i => i.Fathername == "Another").ID,
                Begin_date=DateTime.Parse("2011-09-01"),
                End_date=DateTime.Parse("2017-08-05"),
                Priority=1,
                Test_comment="тестим, тестим" },
               new Project {
                //ID = 4434,
                Name ="Rules Advanced 2",
                Customer_Company ="Embracodero",
                Executive_Company ="Foran",
                ManagerID=Workers.Single( i => i.ID == 4).ID,

                Begin_date=DateTime.Parse("2015-09-01"),
                End_date=DateTime.Parse("2018-08-05"),
                Priority=1,
                Test_comment="комментарий разработчика " }

            };
            foreach (Project s in Projects)
            {
                context.Projects.Add(s);
            }
            context.SaveChanges();
            var ProjectAssignments = new ProjectAssignment[]
             {
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 1).ID,
                        WorkerID = Workers.Single( i => i.ID == 1).ID,
                    },
                     new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 1).ID,
                        WorkerID = Workers.Single( i => i.ID == 2).ID,
                    },
                     new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 1).ID,
                        WorkerID = Workers.Single( i => i.ID == 3).ID,
                    },
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 2).ID,
                        WorkerID = Workers.Single( i => i.ID == 1).ID,
                    },
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 3).ID,
                        WorkerID = Workers.Single( i => i.ID == 1).ID,
                    },
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 4).ID,
                        WorkerID = Workers.Single( i => i.ID == 1).ID,
                    },
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 2).ID,
                        WorkerID = Workers.Single( i => i.ID == 2).ID,
                    },
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 2).ID,
                        WorkerID = Workers.Single( i => i.ID == 3).ID,
                    },
                    new ProjectAssignment
                    {
                        ProjectID = Projects.Single( i => i.ID == 2).ID,
                        WorkerID = Workers.Single( i => i.ID == 4).ID,
                    }

             };
            foreach (ProjectAssignment ss in ProjectAssignments)
            {
                context.ProjectAssignments.Add(ss);
            }
            context.SaveChanges();





        }
    }
}