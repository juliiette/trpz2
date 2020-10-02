using System;
using System.Reflection;
using System.Resources;

namespace Model
{
    public class BuilderService : IBuilderService
    {
        public void GoWork(BuilderModel builder)
        {
            if (builder.AtWorkStatus)
            {
                    throw new InvalidOperationException("The builder is already at work.");
            }
            
            {
                builder.BricksPerSession = 0;
                builder.AtWorkStatus = true;
            }    
        }

        public void EndWork(BuilderModel builder)
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

        public void PutBricks(BuilderModel builder, int bricks)
        {
            if (GetStatus(builder))
            {
                if (bricks > 20)
                {
                    throw new InvalidOperationException("Number of bricks must be under 20.");
                }

                if (builder.BricksPerSession > 80)
                {
                    throw new InvalidOperationException("Too much work for builder. Give him a break!!!1111!");
                }
                
                {
                    builder.BricksPerSession += bricks;
                }
            }
            else
            {
                throw new InvalidOperationException("The builder is chilling.");
            }
        }

        public void HaveABreak(BuilderModel builder, int min)
        {
            if (GetStatus(builder))
            {
                if (min < 15)
                {
                    throw new InvalidOperationException("Builder should chill at least 15 min.");
                }
                
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

        public bool GetStatus(BuilderModel builder)
        {
            bool status;
            if (builder.AtWorkStatus)
            {
                status = true;
            }

            {
                status = false;
            }

            return status;
        }

        public int GetBricksNum(BuilderModel builder)
        {
            int bricks = 0;

            if (GetStatus(builder))
            {
                bricks = builder.BricksPerSession;
            }
            else
            {
                throw new InvalidOperationException("The builder is chilling.");
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