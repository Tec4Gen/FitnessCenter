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

        public void Add(Lesson lesson, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            try
            {
                _lessonDao.Add(lesson);
            }
            catch
            {

                listError.Add(new Error
                {
                    Message = "Internal error, try again"
                });
            }
           
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _lessonDao.GetAll();
        }

        public Lesson GetById(int id)
        {
            return _lessonDao.GetById(id);
        }

        public void Remove(int id, out ICollection<Error> listError)
        {
            listError = new List<Error>();

            try
            {
                if (_lessonDao.GetById(id) == null)
                {
                    listError.Add(new Error
                    {
                        Message = "Lesson won't find"
                    });
                    return;
                }
                _lessonDao.Remove(id);
            }
            catch
            {

                listError.Add(new Error
                {
                    Message = "Internal error, try again"
                });
            }
        }

        public void Update(Lesson lesson, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            try
            {
                if (_lessonDao.GetById(lesson.Id) == null)
                {
                    listError.Add(new Error
                    {
                        Message = "Lesson won't find"
                    });
                    return;
                }
                _lessonDao.Update(lesson);
            }
            catch
            {
                listError.Add(new Error
                {
                    Message = "Internal error, try again"
                });
            }
        }
    }
}
