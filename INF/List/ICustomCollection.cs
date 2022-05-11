using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    /// <summary>
    /// Собственная коллекция
    /// </summary>
    public interface ICustomCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Размер коллекции
        /// </summary>
        int Size();

        /// <summary>
        /// Признак пустого списка
        /// </summary>
        bool isEmpty();

        /// <summary>
        /// Имеется ли элемент в коллекции
        /// </summary>
        /// <param name="elem">Элемент, который ищем в коллекции</param>
        bool Contains(T elem);

        /// <summary>
        /// Добавление элемента в конец
        /// </summary>
        void Add(T elem);

        /// <summary>
        /// Добавление в конец нескольких элементов
        /// </summary>
        /// <param name="elems"></param>
        void AddRange(T[] elems);

        /// <summary>
        /// Удаление элемента со значением
        /// </summary>
        void Remove(T elem);

        /// <summary>
        /// Удаляет все элементы со значением
        /// </summary>
        void RemoveAll(T elem);

        /// <summary>
        /// Удаление элемента на позиции с номером 
        /// </summary>
        void RemoveAt(int index);

        /// <summary>
        /// Очищение коллекции
        /// </summary>
        void Clear();

        /// <summary>
        /// Переворачивает список
        /// </summary>
        void Reverse();

        /// <summary>
        /// Вставка элемента на конкретную позицию
        /// </summary>
        void Insert(T elem, int index);

        /// <summary>
        /// Возвращает позицию элемента
        /// </summary>
        int IndexOf(T elem);

        public void WriteToConsole();
    }
}
