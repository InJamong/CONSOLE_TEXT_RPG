using Player;
using Skill;
using Job;
namespace TEXT_RPG_만들기
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("플레이어 이름을 입력하세요: ");
            string playerName = Console.ReadLine();

            // 직업 선택
            Console.WriteLine("직업을 선택하세요 (1. 전사 / 2. 법사): ");
            string jobInput = Console.ReadLine();
            CJob selectedJob;

            // 직업 설정
            if (jobInput == "1")
                selectedJob = new CWarrior();
            else if (jobInput == "2")
                selectedJob = new CMage();
        }
    }
}
