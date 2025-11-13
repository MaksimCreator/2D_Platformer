# 2D_Platformer Game - MVP (Pasive View); AI - MVP (Pasive View) And Blackboard;
Seting Game are in Scriptable Object
Scriptable Object are in Source (SO)
Code are in Source;
Management: jump - Space, left Move - left arrow, rigth Move - right arrow
Stack - Zenject, UniTask, DoTween,Newtonsoft.Json,MVP (Pasive View), Blacknoaed, New Input System

• EntryPoint — точка входа.
• GameLoop — заменяет MonoBehaviour, даёт C# классам игровые события без MonoBehaviour. Игровые события в Source -> Model -> GameEvent.
• В Blackboard не использовал Sensor, так как у AI всего одно состояние. Sensor тут не нужен.
• CharacterViewFactory не создаёт Characters, так как это офлайн-игра. Здесь Character 1 на всю игру. Create/Destroy включают/выключают объект.
• Архитектуру старался сделать не связанной и не сильно абстрактной.
