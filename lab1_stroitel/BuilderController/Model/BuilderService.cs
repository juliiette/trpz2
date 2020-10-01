using System;
using System.Reflection;
using System.Resources;

namespace Model
{
    public class BuilderService : IBuilderService
    {
        BuilderService _builderService = new BuilderService();

        public void GoWork(BuilderModel builder)
        {
            try
            {
                if (builder.AtWorkStatus)
                {
                    throw new InvalidOperationException("The builder is already at work.");
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
                    throw new InvalidOperationException("The builder is chilling.");
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
                        throw new InvalidOperationException("Number of bricks must be under 20.");
                    }

                    if (builder.BricksPerSession > 80)
                    {
                        throw new InvalidOperationException("Too much work for builder. He will have break now.");
                        _builderService.HaveABreak(builder, 15);
                    }
                    else
                    {
                        builder.BricksPerSession += bricks;
                    }
                }
                else
                {
                    throw new InvalidOperationException("The builder is chilling.");
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
                        throw new InvalidOperationException("Builder should chill at least 15 min.");
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
                    throw new InvalidOperationException("The builder is chilling.");
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
                    throw new InvalidOperationException("The builder is chilling.");
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

        public BuilderModel AddBuilder(int id, string name, bool atWorkStatus, int bricksPerSession, int minOnBreak)
        {
            BuilderModel builder = new BuilderModel();
            builder.Id = id;
            builder.Name = name;
            builder.AtWorkStatus = atWorkStatus;
            builder.BricksPerSession = bricksPerSession;
            builder.MinOnBreak = minOnBreak;

            return builder;
        }
    }
}