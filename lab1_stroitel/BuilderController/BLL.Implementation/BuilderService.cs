using System;
using System.Reflection;
using System.Resources;
using BLL.Abstract;
using BLL.Implementation.Exceptions;
using BLL.Models;

namespace BLL.Implementation
{
    public class BuilderService : IBuilderService
    {
        
        public void GoWork(BuilderModel builder)
        {
            try
            {
                if (builder.AtWorkStatus)
                {
                    // var resManager = new ResourceManager("BLL.Implementation/Resources/ExceptionMessages.resx", Assembly.GetExecutingAssembly());
                    // throw new BuilderAtWorkException(resManager.GetString("BuilderAtWork"));
                    throw new BuilderAtWorkException("The builder is already at work.");
                }
                else
                {
                    builder.BricksPerSession = 0;
                    builder.AtWorkStatus = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }

        public void EndWork(BuilderModel builder)
        {
            try
            {
                if (builder.AtWorkStatus)
                {
                    builder.AtWorkStatus = false;
                }
                else
                {
                    throw new BuilderNotAtWorkException("The builder is chilling.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void PutBricks(BuilderModel builder, int bricks)
        {
            try
            {
                if (GetStatus(builder))
                {
                    if (bricks > 20)
                    {
                        throw new LimitedBricksPerSessionException("Number of bricks must be under 20.");
                    }

                    if (builder.BricksPerSession > 80)
                    {
                        throw new LimitedBricksPerSessionException("Too much work for builder. He will have break now.");
                        HaveABreak(builder, 15);
                    }
                    else
                    {
                        builder.BricksPerSession += bricks;
                    }
                }
                else
                {
                    throw new BuilderNotAtWorkException("The builder is chilling.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void HaveABreak(BuilderModel builder, int min)
        {
            try
            {
                if (GetStatus(builder))
                {
                    if (min < 15)
                    {
                        throw new MoreTimeForBreakException("Builder should chill at least 15 min.");
                    }
                    else
                    {
                        builder.AtWorkStatus = false;
                        builder.MinOnBreak = min;
                        builder.BricksPerSession = 0;
                    }
                }
                else
                {
                    throw new BuilderNotAtWorkException("The builder is chilling.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool GetStatus(BuilderModel builder)
        {
            bool status = false;
            try
            {
                if (builder.AtWorkStatus)
                {
                    status = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return status;
        }

        public int GetBricksNum(BuilderModel builder)
        {
            int bricks = 0;

            try
            {
                if (GetStatus(builder))
                {
                    bricks = builder.BricksPerSession;
                }
                else
                {
                    throw new BuilderNotAtWorkException("The builder is chilling.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return bricks;
        }

        public int GetBreakingTime(BuilderModel builder)
        {
            return builder.MinOnBreak;
        }
    }
}