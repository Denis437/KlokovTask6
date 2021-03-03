using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface Member
    {
        DateTime GotJobTime { get; set; }
        int Income { get; set; }
        int Money { get; set; }
        int DaysInCompany();
        int TotalIncome();
    }
    abstract class Engineer : Member
    {
        public DateTime GotJobTime { get; set; } // дата устройства на работу
        public int Income { get; set; } // зарплата сотрудника в мес
        public virtual int Money { get { return money; } set { money = value; } } // кол-во денег на счету сотрудника
        private int money = 0;
        public int DaysInCompany()
        {
            return (DateTime.Now - GotJobTime).Days;// посчитать кол-во отработанных дней сотрудником
        }
        public int TotalIncome()
        {
            return DaysInCompany() / (365 / 12) * Income;// посчитать кол-во зароботанных денег в общем сотруником
        }
        public void GoToJob() { }
    }
    class Chief : Engineer
    {
        public List<Member> WorkersList { get; set; } // список сотрудников
        public int WorkersLeaved { get; set; } = 0; // кол-во уволенных сотрудников
        public bool GiveIncome(Member Worker)
        {
            if(Money - (Worker.TotalIncome() - Worker.Money) < 0)// если у начальника позволяет бюджет выдать зарплату
            {
                Money = Money - (Worker.Money = Worker.TotalIncome() - Worker.Money);// снять со счета начальника сумму зорплаты, и выдать на счет сотрудника зарплату
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LeaveWorker(Member Worker)
        {
            for(int i = 0; i < WorkersList.Count; i++)// перебрать список сотрудников
            {
                if(WorkersList[i] == Worker)//если сотрудник найден в списке
                {
                    WorkersList.RemoveAt(i);//удалить его из списка
                    WorkersLeaved++;//добавить +1 к кол-ву уволенных сотрудников
                    return;
                }
            }
        }
    }
}
