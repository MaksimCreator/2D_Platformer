using Zenject;

public class EnemyBlackBoard
{
    public readonly EnemyPatrolConfig ConfigEnemy;

    [Inject]
    public EnemyBlackBoard(EnemyPatrolConfig configAI) 
    {
        ConfigEnemy = configAI;
    }
}