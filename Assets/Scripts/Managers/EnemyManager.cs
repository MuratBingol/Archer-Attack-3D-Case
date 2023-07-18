namespace Managers
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        public int areaCount;


        public void RemoveArea()
        {
             areaCount--;
                Invoke(nameof(ControlCount),0.5f);
        }

        private void ControlCount()
        {
            if (areaCount>0)
            {
                EventManager.OnSetAction?.Invoke(ActionType.run);
                return;
            }
            if (areaCount == 0)
            {
                EventManager.OnWin?.Invoke();
            } 
        }
    }
}