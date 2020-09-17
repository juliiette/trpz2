using BLL.Models;

namespace BLL.Abstract
{
    public interface IBuilderService
    {
        void GoWork(BuilderModel builder);

        void EndWork(BuilderModel builder);

        void PutBricks(BuilderModel builder, int bricks);

        void HaveABreak(BuilderModel builder, int min);

        bool GetStatus(BuilderModel builder);

        int GetBricksNum(BuilderModel builder);

        int GetBreakingTime(BuilderModel builder);

        BuilderModel AddBuilder(int id, string name, bool atWorkStatus, int bricksPerSession, int minOnBreak);
    }
}