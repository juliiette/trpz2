using System;
using Model;
using Microsoft.Extensions.DependencyInjection;

namespace BuilderConsole
{
    class Program
    {
        private static IServiceProvider DependencyResolver { get;  set; }
        
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IBuilderService, BuilderService>();
            DependencyResolver = services.BuildServiceProvider();
            
            BuilderService builderService = new BuilderService();
            BuilderModel builder = builderService.AddBuilder(131, "Виталик", false, 32, 5);

            Console.Title = "Builder Console";
            Console.WriteLine("Write help for help.");
            
            
            while (true)
            {
                Console.Write("user> ");
                string line = Console.ReadLine();

                switch (line)
                {
                    case "help":
                    {
                        string[] commands = new string[]
                        {
                            "info        Возвращает инфу про строителя",
                            "gowork      Посылает строителя на работу",
                            "endwork     Забирает строителя с работы домой",
                            "bricks      Задать к-во кирпичиков",
                            "break       Отправить строителя на переменку",
                            "status      Узнать чё делает",
                            "rbricks     Узнать скок уже положил кирпичиков",
                            "mbreak      Узнать скок он уже отдыхал"

                        };
                        foreach (var str in commands)
                        {
                            Console.WriteLine(str);
                        }
                    }
                        break;
                    case "info":
                    {
                        Console.WriteLine(" ID       NAME        AT WRK?        BRCKS/SESSION        BRK TIME");
                        Console.WriteLine(builder.Id + "      " + builder.Name + "       "+ builder.AtWorkStatus + "             "+builder.BricksPerSession
                                          +"                  "+builder.MinOnBreak);
                    }
                        break;
                    
                    case "gowork":
                    {
                        builderService.GoWork(builder);
                    }
                        break;
                    
                    case "endwork":
                    {
                        builderService.EndWork(builder);
                    }
                        break;
                    
                    case "bricks":
                    {
                        Console.WriteLine("Скок кирпичиков:");
                        Console.Write("user> ");
                        string num = Console.ReadLine();
                        int n = Int32.Parse(num);
                        builderService.PutBricks(builder, n);
                    }
                        break;
                    
                    case "break":
                    {
                        Console.WriteLine("Сколько отдыхать (в минутах):");
                        Console.Write("user> ");
                        string num = Console.ReadLine();
                        int n = Int32.Parse(num);
                        builderService.HaveABreak(builder, n);
                    }
                        break;
                    
                    case "status":
                    {
                        Console.WriteLine("Работает?");
                        Console.WriteLine(builderService.GetStatus(builder));
                    }
                        break;
                    
                    case "rbricks":
                    {
                        int bricks = builderService.GetBricksNum(builder);
                        Console.Write("Положено кирпичиков:  " + bricks);
                        
                    }
                        break;
                    
                    case "mbreak":
                    {
                        int min = builderService.GetBreakingTime(builder);
                        Console.WriteLine("Отдыхал минут:  " + min);
                        
                    }
                        break;
                    
                }
            }
            
        }
    }
}