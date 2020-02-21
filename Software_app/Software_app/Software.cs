using System;

namespace Software_app
{
    /// <summary>
    /// Абстрактный класс для реализации ПО.
    /// </summary>
    abstract class Software
    {
        /// <summary>
        /// Переменная для хранения названия ПО.
        /// </summary>
        protected string softName;

        /// <summary>
        /// Переменная для хранения производиетля ПО.
        /// </summary>
        protected string softProducer;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="softName">Название ПО</param>
        /// <param name="softProducer">Производитель ПО</param>
        public Software(string softName, string softProducer)
        {
            this.softName = softName;
            this.softProducer = softProducer;
        }

        /// <summary>
        /// Метод для вывода названия и производителя ПО.
        /// </summary>
        /// <returns>Возвращает string с названием ПО 
        /// и производителем ПО. </returns>
        public string WriteFullName()
        {
            return "Comp.: " + softProducer + ", " + "Software Name: " + softName;
        }

        /// <summary>
        /// Абстрактный метод для вывода полной информации по ПО.
        /// </summary>
        public abstract void GetInformation();

        /// <summary>
        /// Абстрактный метод для определения 
        /// возможности пользоваться ПО.
        /// </summary>
        /// <returns>Возвращает true, если пользователь 
        /// может использовать ПО, иначе false.</returns>
        public abstract bool ReadyWork();

    }

    /// <summary>
    /// Класс, реализующий свободное ПО.
    /// </summary>
    class FreeSoft : Software
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public FreeSoft(string softName, string softProducer) : base(softName, softProducer) { }

        /// <summary>
        /// Метод для вывода в консоль информации
        /// о свободном ПО.
        /// </summary>
        public override void GetInformation()
        {
            Console.WriteLine("Software name: " + softName);
            Console.WriteLine("Producer name: " + softProducer);
        }

        /// <summary>
        /// Метод, показывающий возможность 
        /// использования свободного ПО.</summary>
        /// <returns>Всегда возвращает true.</returns>
        /// <remarks>Всегда true, потому что 
        /// это свободное ПО.</remarks>
        public override bool ReadyWork()
        {
            return true;
        }
    }

    /// <summary>
    /// Класс, реализующий условно-бесплатное ПО.
    /// </summary>
    class Shareware : Software
    {
        /// <summary>
        /// Дата установки ПО.
        /// </summary>
        DateTime installationDate;

        /// <summary>
        /// Переменная для хранения количества дней
        /// бесплатного пользования.
        /// </summary>
        int freeUsePeriodDay;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Shareware(string softName, string softProducer,
            DateTime installationDate, int freeUsePeriodDay) : base(softName, softProducer)
        {
            this.installationDate = installationDate;
            this.freeUsePeriodDay = freeUsePeriodDay;
        }

        /// <summary>
        /// Метод для вывода в консоль информации
        /// о условно-бесплатном ПО.
        /// </summary>
        public override void GetInformation()
        {
            Console.WriteLine("Software name: " + softName);
            Console.WriteLine("Producer name: " + softProducer);
            Console.WriteLine("Software installation date: " + installationDate.ToString("d"));
            Console.WriteLine("Period of free use: " + freeUsePeriodDay);
        }

        /// <summary>
        /// Метод, показывающий возможность 
        /// использования условно-бесплатного ПО.</summary>
        /// <returns>Возвращает true, если пользователь 
        /// может использовать условно-бесплатное 
        /// ПО, иначе false.</returns>
        public override bool ReadyWork()
        {
            return DateTime.Today.Subtract(installationDate).Days <= freeUsePeriodDay;
        }
    }

    /// <summary>
    /// Класс, реализуюший коммерческое ПО.
    /// </summary>
    class CommercialSoft : Software
    {
        /// <summary>
        /// Цена ПО.
        /// </summary>
        double cost;

        /// <summary>
        /// Дата установки ПО.
        /// </summary>
        DateTime installationDate;

        /// <summary>
        /// Период платной подписки.
        /// </summary>
        int UsePeriodDay;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public CommercialSoft(string softName, string softProducer, double cost,
            DateTime installationDate, int UsePeriodDay) : base(softName, softProducer)
        {
            this.cost = cost;
            this.installationDate = installationDate;
            this.UsePeriodDay = UsePeriodDay;
        }

        /// <summary>
        /// Метод для вывода в консоль информации
        /// о коммерческом ПО.
        /// </summary>
        public override void GetInformation()
        {
            Console.WriteLine("Software name: " + softName);
            Console.WriteLine("Producer name: " + softProducer);
            Console.WriteLine("Cost: " + cost + "$");
            Console.WriteLine("Software installation date: " + installationDate.ToString("d"));
            Console.WriteLine("Period of use: " + UsePeriodDay);
        }

        /// <summary>
        /// Метод, показывающий возможность 
        /// использования коммерческого ПО.</summary>
        /// <returns>Возвращает true, если пользователь 
        /// может использовать коммерческое 
        /// ПО, иначе false.</returns>
        public override bool ReadyWork()
        {
            return DateTime.Today.Subtract(installationDate).Days <= UsePeriodDay;
        }
    }
}
