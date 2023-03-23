﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_schedule
{
    public static class FormSettings
    {
        /// <summary>
        /// Коментарий для ползователя Sound
        /// </summary>
        static public bool Sound { get; set; } = true;

        /// <summary>
        /// Коментарий для ползователя Message
        /// </summary>
        static public bool Message { get; set; } = false;
        static public bool ShowBreaks { get; set; } = true;
        static public string Language { get; set; } = "Русский";
        static public string LessonNow { get; set; }
        static public double Opacity { get; set; } = .75;
        static public Dictionary<string, string[][]> Schedule { get; }
        static public Dictionary<DateTime, string> ScheduleTime { get; }

        static FormSettings()
        {
            // Расписание уроков
            Schedule = new Dictionary<string, string[][]>()
            {
                {
                    "Monday", new string[][] // Понедельник
                    {
                         new string[] {"1","МДК 01 02","08:15 - 08:55","Елисеев В.Д.","№3"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2","МДК 01 02","09:00 - 09:40", "Елисеев В.Д.", "№3"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3","МДК 01 02","09:50 - 10:30", "Елисеев В.Д.", "№3"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4","МДК 01 02", "10:50 - 11:30", "Елисеев В.Д.", "№3"},
                         new string[] {"", "Б", "11:30 - 11:50","",""},
                         new string[] {"5","МДК 01 02","11:50 - 12:25", "Елисеев В.Д.", "№3"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6","МДК 01 02", "12:45 - 13:20", "Елисеев В.Д.", "№3"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7","Англ.яз", "13:30 - 14:05", "Борисова Ю.В.","№7"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8","Англ.яз", "14:10 - 14:45", "Борисова Ю.В.", "№7"},
                    }
                },
                {
                    "Tuesday", new string[][] // Вторник
                    {
                         new string[] {"1","Теория Вероятности","08:15 - 08:55","Бережной А.В.","№1"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "Теория Вероятности", "09:00 - 09:40", "Бережной А.В.", "№1"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3","Безопасность Жизнедеятельности","09:50 - 10:30","Олейников С.В.","№4"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "Безопасность Жизнедеятельности", "10:50 - 11:30", "Олейников С.В.", "№4"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5","Элементы Высшей Логики","11:50 - 12:25","Чернявская Н.Н.","№15"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "Элементы Высшей Логики", "12:45 - 13:20", "Чернявская Н.Н.", "№15"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7","Технические средства", "13:30 - 14:05", "Елисеев В.Д.", "№1"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8","Технические средства", "14:10 - 14:45", "Елисеев В.Д.", "№1"},
                    }
                },
                {
                    "Wednesday", new string[][] // Среда
                    {
                         new string[] {"1","Информационный час","08:15 - 08:55","Лукьяненко Д.В.","№7"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "Элементы Математической Логики", "09:00 - 09:40", "Чернявская Н.Н.", "№15"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3", "Элементы Математической Логики", "09:50 - 10:30", "Чернявская Н.Н.", "№15"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "Физ-ра", "10:50 - 11:30", "Темная Н.О", "-"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5", "Физ-ра", "11:50 - 12:25", "Темная Н.О", "-"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "МДК 01 01", "12:45 - 13:20", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7", "МДК 01 01", "13:30 - 14:05", "Елисеев В.Д.", "№1"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8", "МДК 01 01", "14:10 - 14:45", "Елисеев В.Д.", "№1"},
                    }
                },
                {
                    "Thursday", new string[][] // Четверг
                    {
                         new string[] {"1", "Элементы Математической Логики","08:15 - 08:55", "Чернявская Н.Н.", "№15"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "Элементы Математической Логики", "09:00 - 09:40", "Чернявская Н.Н.", "№15"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3", "Технические средства", "09:50 - 10:30", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "Технические средства", "10:50 - 11:30", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5", "МДК 01 01", "11:50 - 12:25", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "МДК 01 01", "12:45 - 13:20", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7", "МДК 01 01", "13:30 - 14:05", "Елисеев В.Д.", "№1"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8", "-", "14:10 - 14:45", "", ""},
                    }
                },
                {
                    "Friday", new string[][] // Пятница
                    {
                         new string[] {"1","Теория Вероятности","08:15 - 08:55", "Бережной А.В.", "№1"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "МДК 01 02", "09:00 - 09:40", "Елисеев В.Д.", "№1"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3", "МДК 01 02", "09:50 - 10:30", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "МДК 01 02", "10:50 - 11:30", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5", "МДК 01 02", "11:50 - 12:25", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "МДК 01 02", "12:45 - 13:20", "Елисеев В.Д.", "№1"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7", "МДК 01 02", "13:30 - 14:05", "Елисеев В.Д.", "№1"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8", "-", "14:10 - 14:45", "", ""},
                    }
                },

            };

            // Расписание звонков
            ScheduleTime = new Dictionary<DateTime, string>()
            {
                {DateTime.Parse("8:15"), "1 урок" },
                {DateTime.Parse("8:55"), "Перемена" },
                {DateTime.Parse("9:00"), "2 урок" },
                {DateTime.Parse("9:40"), "Перемена" },
                {DateTime.Parse("9:50"), "3 урок" },
                {DateTime.Parse("10:30"), "Большая перемена" },
                {DateTime.Parse("10:50"), "4 урок" },
                {DateTime.Parse("11:30"), "Большая перемена" },
                {DateTime.Parse("11:50"), "5 урок" },
                {DateTime.Parse("12:25"), "Большая перемена" },
                {DateTime.Parse("12:45"), "6 урок" },
                {DateTime.Parse("13:20"), "Перемена" },
                {DateTime.Parse("13:30"), "7 урок" },
                {DateTime.Parse("14:05"), "Перемена" },
                {DateTime.Parse("14:10"), "8 урок" },
                {DateTime.Parse("14:45"), "Конец учебного дня" },

            };

        }

    }
}
