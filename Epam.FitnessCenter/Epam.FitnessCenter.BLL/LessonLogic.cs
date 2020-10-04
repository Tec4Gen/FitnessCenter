using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL
{
    public class LessonLogic : ILessonLogic
    {
        private ILessonDao _lessonDao;

        public LessonLogic(ILessonDao lessonDao)
        {
            _lessonDao = lessonDao;
        }

        public void Add(Lesson lesson, out IEnumerable<Error> listError)
        {
            listError = new List<Error>();
            _lessonDao.Add(lesson);
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _lessonDao.GetAll();
        }

        public Lesson GetById(int id)
        {
            return _lessonDao.GetById(id);
        }

        public void Remove(int id, out IEnumerable<Error> listError)
        {
            listError = new List<Error>();
            _lessonDao.Remove(id);
        }

        public void Update(Lesson lesson, out IEnumerable<Error> listError)
        {
            listError = new List<Error>();
            _lessonDao.Update(lesson);
        }
    }
}
