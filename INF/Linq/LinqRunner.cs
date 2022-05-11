using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Linq
{
    public class LinqRunner
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;

            //Для того, чтобы сравнивать объекты в последовательностях
            public override bool Equals(object obj)
            {
                if (obj is Student st)
                    return ID == st.ID;
                return false;
            }
            public override int GetHashCode() => ID.GetHashCode();
        }

        /// <summary>
        /// Класс своего правила для сравнения студентов, который исп-ся в сортировке
        /// </summary>
        public class CustomStudentsComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                var xAverageScore = x.Scores.Average();
                var yAverageScore = y.Scores.Average();
                return xAverageScore.CompareTo(yAverageScore);
            }
        }

        private class StudentFirstLast
        {
            public string First { get; set; }
            public string Last { get; set; }
        }

        /// <summary>
        /// Группа здоровья студентов
        /// </summary>
        private class StudentHealthGroup
        {
            public int StudentId { get; set; }
            public int HealthGroupId { get; set; }
        }
        /// <summary>
        /// Справочник групп здоровья
        /// </summary>
        private class HealthGroup
        {
            public int HealthGroupId { get; set; }
            public string HealthGroupName { get; set; }
        }
        public void Run()
        {
            var students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores = new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores = new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores = new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", ID=115, Scores = new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", ID=116, Scores = new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores = new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", ID=118, Scores = new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores = new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores = new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores = new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores = new List<int> {94, 92, 91, 91}}
            };
            var students2 = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores = new List<int> {75, 84, 91, 39}},
                new Student {First="Renata", Last="Garifullina", ID=113, Scores = new List<int> {88, 94, 65, 91}},
                new Student {First="Renata", Last="Garifullina", ID=113, Scores = new List<int> {88, 94, 65, 91}},
                new Student {First="Renata", Last="Garifullina", ID=113, Scores = new List<int> {88, 94, 65, 91}},
                new Student {First="Renata", Last="Garifullina", ID=113, Scores = new List<int> {88, 94, 65, 91}},
                new Student {First="Michael", Last="Abramski", ID=114, Scores = new List<int> {97, 89, 85, 82}},
                new Student {First="Farid", Last="Salimov", ID=115, Scores = new List<int> {35, 72, 91, 70}}
            };
            //Извлечь все имена студентов
            //Способ 1. сделать вручную через foreach/for/while
            var res1 = new List<string>();
            foreach (var student in students)
            {
                res1.Add(student.Last);
            }
            //Способ 2. Linq синтаксис выражения запросов
            var res2 =
                (from student in students
                 select student.Last).ToList();
            //Способ 3. Linq текучий синтаксис, или синтаксис цепочки операций запросов
            var res3 = students.Select(x => x.Last).ToList();

            //Извлечь имена и фамилии
            //Способ 1. Через заранее определенный класс
            var res4 = students
                .Select(x => new StudentFirstLast()
                {
                    First = x.First,
                    Last = x.Last
                }).ToList();
            //Способ 2. Использование анонимного типа, или анонимного класса
            var res5 = students
                .Select(x => new
                {
                    CurrentTime = DateTime.Now.ToShortDateString(),
                    FullName = x.First + x.Last,
                    x.First,
                    x.Last
                }).ToList();

            //Выбрать все фамилии студентов, у которых в имени есть буква a
            var res6 = students
                .Where(x => x.First.Contains('a'))
                .Select(x => x.Last)
                .ToList();
            //Выбрать фамилии всех студентов, 
            //у которых в фамилии и имени есть буква а
            var res7 = students
                .Where(x => x.First.Contains('a') && x.Last.Contains('a'))
                .Select(x => x.Last)
                .ToList();

            //Если у студента первый балл выше 75, то брать только тех студентов,
            //у которых есть буква а в имени
            var res8 = students
                .Where(x =>
                {
                    if (x.Scores[0] > 75) return x.First.Contains('a');//contains возвращает true/false
                    else return true;
                })
                .ToList();
            //сортировки OrderBy, OrderByDescending, ThenBy, ThenByDescending
            //мы смотрели. Попробуем сортировать, используя свое правило.
            //отсортируем в порядке увеличения средней оценки
            //Вариант 1: использование average LINQ - агрегатная функция , см ниже
            var res9 = students
                .OrderBy(x => x.Scores.Average())
                .Select(x => new
                {
                    x.First,
                    x.Last
                });
            //Вариант 2: зададим свое правило сортировки
            var res10 = students
                .OrderBy(x => x, new CustomStudentsComparer())
                .Select(x => new
                {
                    x.First,
                    x.Last
                });
            //Объединение, пересечение и разность коллекций 
            //(не забудь переопределить Equals и GetHashCode)
            //Except() - разность
            var res11 = students.Except(students2);
            //Intersect - пересечение
            var res12 = students.Intersect(students2);
            //Distinct - удаление дубликатов
            var res13 = students2.Distinct();
            //Для объединения двух последовательностей используется метод Union. 
            //Его результатом является новый набор, в котором имеются элементы, 
            //как из первой, так и из второй последовательности. 
            //Повторяющиеся элементы добавляются в результат только один раз
            var res15 = students.Union(students2);

            //К агрегатным операциям относят различные операции над выборкой, 
            //например, получение числа элементов, получение минимального, 
            //максимального и среднего значения в выборке, 
            //а также суммирование значений.
            //Agregate - посмотрите на метаните https://metanit.com/sharp/tutorial/15.5.php
            //Count - кол-ва элементов
            var res16 = students.Count(); //хотя у листа есть students.Count
                                          //Sum - сумма. Посчитаем сумму средних оценок
            var res17 = students.Sum(x => x.Scores.Average());
            //Min(), Max(), Average() - минимальное, максимальное и среднее значения соотв-но
            //найдем минимальную среднюю оценку
            var res18 = students.Min(x => x.Scores.Average());
            //Найдем среднее значение средних оценок
            var res19 = students.Average(x => x.Scores.Average());
            //Skip() пропускает определенное количество элементов
            var res20 = students.Skip(3);
            //SkipWhile() пропускает цепочку элементов, начиная с первого элемента, 
            //пока они удовлетворяют определенному условию
            //Take() извлекает определенное число элементов
            //TakeLast() извлекает определенное количество элементов с конца коллекции
            //TakeWhile() выбирает цепочку элементов, начиная с первого элемента, 
            //пока они удовлетворяют определенному условию
            //П.С. Если вы реализуете постраничный вывод коллекций, 
            //на каждой странице n строк, то для i-ой страницы список будет
            //list.Skip(n*(i-1)).Take(n)

            //Группировка.  GroupBy()
            //Результатом оператора group является выборка, 
            //которая состоит из групп. Каждая группа представляет объект 
            //IGrouping<K, V>: параметр K указывает на тип ключа - 
            //тип свойства, по которому идет группировка (здесь это тип string). 
            //А параметр V представляет тип сгруппированных объектов - 
            //в данном случае группируем объекты Student.
            var res21 = students.GroupBy(x => x.Last);
            // Мы можем совершать операции над каждой из групп.
            //Например, посчитать количество объектов в группе:
            var res22 = students
                .GroupBy(x => x.Last)
                .Select(g => new { Last = g.Key, Count = g.Count() });
            //Вложенный запрос https://ru.wikipedia.org/wiki/%D0%92%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%BD%D1%8B%D0%B5_%D0%B7%D0%B0%D0%BF%D1%80%D0%BE%D1%81%D1%8B
            //По-простому вложенный запрос - запрос внутри другого запроса
            //Пример: сгруппировать по Фамилиям, 
            //внутри каждой фамилии вывести имена в алфавитном порядке
            var res23 = students
                .GroupBy(x => x.Last)
                .Select(g => new
                {
                    Last = g.Key,
                    Count = g.Count(),
                    Firsts = g.Select(x => x.First).OrderBy(x => x)
                });


            //Работа с несколькими коллекциями одновременно

            ///Справочник групп здоровья
            var healthGroups = new List<HealthGroup>
        {
            new HealthGroup(){ HealthGroupId = 1, HealthGroupName = "Основная"},
            new HealthGroup(){ HealthGroupId = 2, HealthGroupName = "Оздоровительная"}
        };
            ///Перечень студентов и их групп здоровья
            var studentsHealthGroup = new List<StudentHealthGroup>()
        {
            new StudentHealthGroup(){ StudentId = 111, HealthGroupId = 1},
            new StudentHealthGroup(){ StudentId = 113, HealthGroupId = 2},
            new StudentHealthGroup(){ StudentId = 115, HealthGroupId = 1},
            new StudentHealthGroup(){ StudentId = 117, HealthGroupId = 2},
            new StudentHealthGroup(){ StudentId = 119, HealthGroupId = 1},
        };

            //Join - соединение двух таблиц
            //Для каждого студента вывести его группу здоровья
            var res24 = students.Join(studentsHealthGroup,
                s => s.ID,
                shg => shg.StudentId,
                (s, shg) => new { s.First, s.Last, shg.HealthGroupId });
            //GroupJoin и Zip посмторите сами
            //Кванторы, существование, проверка наличия
            //All() проверяет, соответствуют ли все элементы условию
            //Проверим, у всех ли средний балл больше 50:
            var res25 = students.All(x => x.Scores.Average() > 50);
            //Any() возвращает true, если хотя бы один элемент коллекции 
            //удовлетворяет определенному условию
            var res26 = students.Any(x => x.Scores.Average() > 50);
            //Contains() возвращает true, если коллекция содержит определенный элемент
            var res27 = students
                .Contains(new Student() { First = "Hugo", Last = "Garcia" });
            //First() возвращает первый элемент последовательности; 
            //если коллекция пуста или в коллекции нет элементов, 
            //который соответствуют условию, то будет сгенерировано исключение
            //Можно задать условие, тогда вернет первый элемент, удовл-й условию
            var res28 = students.First(x => x.First == "Svetlana");
            //Если хотим без исключений, используем FirstOrdefault, который 
            //при отсутствии соотв-го элемента вернет значение по умолчанию
            //Аналогично работает пара Last и LastOrDefault
        }
    }
}
