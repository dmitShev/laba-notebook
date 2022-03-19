using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    /*
    * Очередное приключение в Рейд-режиме ждёт! Условия и задачи текущей стадии находятся в файле Conditions.txt.
    */

    public class Notebook
    {
        public Dictionary<int, Note> allNotes = new Dictionary<int,Note>();
        public static int id = 0;

        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!");
            Console.WriteLine("	- для создания новой записи введите команду: create.");
            Console.WriteLine("	- для просмотра записи введите команду: show.");
            Console.WriteLine("	- для редактирования записи введите команду: edit.");
            Console.WriteLine("	- для удаления записи введите команду: del.");
            Console.WriteLine("	- для просмотра списка всех записей введите команду: all.");
            Console.WriteLine("	- для выхода из программы введите команду: exit.");
        }


        private void Action()
        {
            Greetings();
            string s;
            while (true)
            {
                Console.Write("Введите команду: ");
                while (true)
                {
                    s = Console.ReadLine();

                    if (!(s != "create" && s != "show" && s != "edit" && s != "del" && s != "all" && s != "exit"))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                }
                if (s == "create")
                {
                    CreateNote();
                }
                else if (s == "show")
                {
                    ReadNote();
                }

                else if (s == "edit")
                {
                    UpdateNote();
                }

                else if (s == "del")
                {
                    DeleteNote();
                }

                else if (s == "all")
                {
                    ShowAllNotes();
                }

                else if (s == "exit")
                {
                    Console.WriteLine("Пока-пока!");
                    return;
                }
            }    
        }

        private void CreateNote()
        {
            Note note = new Note();
            id = allNotes.Count();
            allNotes.Add(id, new Note()
            {
                Id = id,
                Surname = ReadUntilValidationPass("Surname"),
                Name = ReadUntilValidationPass("Name"),
                SecondName = ReadUntilValidationPass("SecondName"),
                Phone = ReadUntilValidationPass("Phone"),
                Country = ReadUntilValidationPass("Country"),
                DateOfBirth = ReadUntilValidationPass("DateOfBirth"),
                Organization = ReadUntilValidationPass("Organization"),
                Position = ReadUntilValidationPass("Position"),
                Remark = ReadUntilValidationPass("Remark")
            });
        }
        private void ReadNote()
        {
            Console.Write("Введите Id записи: ");
            string id;
            id = Console.ReadLine();
            int iid;
            if (int.TryParse(id, out iid))
            {
                if (allNotes.ContainsKey(iid))
                {
                    Console.WriteLine(allNotes[iid].ToString());
                }
                else
                {
                    Console.WriteLine("Данной записи не найдено!");
                }
            }
            else
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }
        }




        private void UpdateNote()
        {
            Console.WriteLine("Укажите ID записи для редактирования: ");
            string input = Console.ReadLine();
            bool next;
            bool cancel = true;
            if (int.TryParse(input, out int id))
            {
                do
                {
                    next = false;
                    if (!allNotes.ContainsKey(id))
                    {
                        Console.WriteLine("Данной записи не найдено!");
                    }
                    else
                    {
                        Console.WriteLine(allNotes[id].ToString());
                        Console.WriteLine("Какое поле необходимо отредактировать?\n" +
                        "\t1 - Фамилия\n" +
                        "\t2 - Имя\n" +
                        "\t3 - Отчество\n" +
                        "\t4 - Телефон\n" +
                        "\t5 - Страна\n" +
                        "\t6 - Дата рождения\n" +
                        "\t7 - Организация\n" +
                        "\t8 - Должность\n" +
                        "\t9 - Примечание");
                        Console.Write("Введите цифру для выбора или cancel для завершения редактирования: ");
                        bool fl = true;
                        do
                        {
                            string print = Console.ReadLine();
                            if (int.TryParse(print, out int result))
                            {
                                switch (result)
                                {
                                    case 1:
                                        fl = false;
                                        allNotes[id].Surname = ReadUntilValidationPass("Surname");
                                        break;
                                    case 2:
                                        fl = false;
                                        allNotes[id].Name = ReadUntilValidationPass("Name");
                                        break;
                                    case 3:
                                        fl = false;
                                        allNotes[id].SecondName = ReadUntilValidationPass("SecondName");
                                        break;
                                    case 4:
                                        allNotes[id].Phone = ReadUntilValidationPass("Phone");
                                        fl = false;
                                        break;
                                    case 5:
                                        fl = false;
                                        allNotes[id].Country = ReadUntilValidationPass("Country");
                                        break;
                                    case 6:
                                        fl = false;
                                        allNotes[id].DateOfBirth = ReadUntilValidationPass("DateOfBirth");

                                        break;
                                    case 7:
                                        fl = false;
                                        allNotes[id].Organization = ReadUntilValidationPass("Organization");
                                        break;
                                    case 8:
                                        fl = false;
                                        allNotes[id].Position = ReadUntilValidationPass("Position");
                                        break;
                                    case 9:
                                        fl = false;
                                        allNotes[id].Remark = ReadUntilValidationPass("Remark");
                                        break;
                                    default:
                                        Console.Write("Команда не найдена! Введите ещё раз: ");
                                        break;
                                }
                            }
                            else if (print == "cancel")
                            {
                                cancel = false;
                                break;
                            }
                            else
                            {
                                Console.Write("Команда не найдена! Введите ещё раз: ");
                            }

                        } while (fl);
                        if (cancel == false)
                        {
                            break;
                        }
                        Console.Write("Поле изменено! Продолжить редактирование записи? (yes/no): ");
                        do
                        {
                            string inp = Console.ReadLine();
                            if (inp == "yes")
                            {
                                next = true;
                                break;
                            }
                            else if (inp == "no")
                            {
                                break;
                            }
                            else
                            {
                                Console.Write("Пожалуйста введите yes или no: ");
                            }
                        } while (true);
                    }
                    Console.Clear();
                } while (next);
            }
            else
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }
        }




            private void DeleteNote()
        {
            Console.Write("Введите Id записи для удаления: ");
            string stringId = Console.ReadLine();
            bool result = int.TryParse(stringId, out int intId);
            if (result)
            {
                if (allNotes.ContainsKey(intId))
                {
                    allNotes.Remove(intId);
                    Console.WriteLine($"Запись {intId} удалена!");
                }
                else Console.WriteLine("Данной записи не найдено!");
            }
            else Console.WriteLine("Введен некорректный идентификатор!");
        }

        private void ShowAllNotes()
        {
            foreach (KeyValuePair<int, Note> item in allNotes)
            {
                Console.WriteLine(item.Value.ToShortString());
            }
        }

        private string ReadUntilValidationPass(string name)
        {
            while (true)
            {
                Console.Write("Введите " + name + ": ");
                string value = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(value))
                {
                    value = null;
                    return value;
                }
                else if (Note.fieldsValidation[name].TryValidate(value, out string error))
                {
                    return value;
                }
                else
                    Console.WriteLine(error);
            }
        }

        public static void Main(string[] args)
        {
            Notebook nt = new Notebook();
            nt.Action();
        }
    }
}