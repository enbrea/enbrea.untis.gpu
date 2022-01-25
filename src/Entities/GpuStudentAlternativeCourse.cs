#region ENBREA UNTIS.GPU - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// An alternative course for <see cref="GpuStudentCourseChoice"/>
    /// </summary>
    public class GpuStudentAlternativeCourse : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuStudentAlternativeCourse"/> class.
        /// </summary>
        /// <param name="lessonId">Lesson id</param>
        /// <param name="subject">Subject</param>
        /// <param name="prioritiy">Priority</param>
        public GpuStudentAlternativeCourse(uint lessonId, string subject, uint prioritiy)
        {
            LessonId = lessonId;
            Subject = subject;
            Priority = prioritiy;
        }

        /// <summary>
        /// School class (Klasse)
        /// </summary>
        public uint Priority { get; set; }

        /// <summary>
        /// Lesson Id (Unterrichtsnummer)
        /// </summary>
        public uint LessonId { get; set; }

        /// <summary>
        /// Subject (Fach)
        /// </summary>
        public string Subject { get; set; }
    }
}
