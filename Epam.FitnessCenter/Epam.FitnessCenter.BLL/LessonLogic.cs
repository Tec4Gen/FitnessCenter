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

        public void Add(Lesson lesson)
        {
            _lessonDao.Add(lesson);
        }

        public IEnumerable<Lesson> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lesson GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Lesson lesson)
        {
            throw new NotImplementedException();
        }
    }
}
