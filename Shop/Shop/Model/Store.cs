﻿using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
   public class Store : IStore
    {
        private List<Showcase> _showcases;
        private const ConsoleKey Back = ConsoleKey.D0;
        public Store()
        {
            _showcases = new List<Showcase>();
        }

        private bool IsAuthenticId(int id)
        {
            if (_showcases.Any(x => x.Id == id))
            {
                Console.WriteLine("Такой Id уже существует");
                return false;
            }
            return true;
        }

        public Showcase FindShowcase()
        {
            if (_showcases.Count == 0)
            {
                Console.WriteLine("Ваш список пуст!");
                return null;
            }
            int Id = Application.InputId();
            foreach (var showacase in _showcases)
            {
                if (showacase.Id == Id)
                    return showacase;
            }
            Console.WriteLine("Такого id не существует!");
            FindShowcase();
            return new Showcase();
        }

        public void AddShowcase()
        {
            int Id = Application.InputId();
            while (!IsAuthenticId(Id))
                Id = Application.InputId();
            string Name = Application.InputName();
            int Size = Application.InputSize();
            var AddedShowcase = new Showcase(Id, Name, Size);
            _showcases.Add(AddedShowcase);
        }

        public void EditNameShowcase()
        {
            Showcase AlterableShowcase = FindShowcase();
            string NewName = Application.InputName();
            AlterableShowcase.Name = NewName;
        }

        public void EditSizeShowcase()
        {
            Showcase AlterableShowcase = FindShowcase();
            int NewSize = Application.InputSize();
            AlterableShowcase.Size = NewSize;
        }

        public void EditIdShowcase()
        {
            Showcase AlterableShowcase = FindShowcase();
            int NewId = Application.InputId();
            while (!IsAuthenticId(NewId))
                NewId = Application.InputId();
            AlterableShowcase.Id = NewId;
        }

        public void PrintShowcases()
        {
            foreach (var showcase in _showcases)
            {
                Console.WriteLine("Id:" + showcase.Id  + 
                    "\nНазвание:" + showcase.Name + 
                    "\nРазмер:" +showcase.Size +
                    "\nДата создания:"+ showcase.CreateTime);
            }
        }

        public void RemoveShowcase()
        {
            PrintShowcases();   
            Console.WriteLine("Для продолжения нажмите любую клавишу\n" +
                "Для выхода нажмите 0");
            var input = Console.ReadKey().Key;
            if (input == Back)
            {
                Console.Clear();
                return;
            }
            _showcases.Remove(FindShowcase());
        }
    }
}
