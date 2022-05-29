using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; //key , required ,MinLength...

namespace WebApplication1.Models
{ 
    public class Student:IBaseData
    {
        public Student()
        {

        }

        public Student(string studentNo, string studentName , string githubLink)
        {
            this.studentNo = studentNo;
            this.studentName = studentName;
            this.githubLink = githubLink;
        }

        [Key] //key值
        [DisplayName("學生學號")] //Create,delete,update設定
        public string studentNo { get; set; }

        [Required(ErrorMessage ="姓名不能為空")]
        [DisplayName("姓名")]
        public string studentName { get; set; }

        [MinLength(10,ErrorMessage= "長度不得小於10")]
        [DisplayName("GitHub連結")]
        public string githubLink { get; set; } 

        
        public bool IsDelete { get ; set ; }//是否刪除
        public DateTime creDateTime { get ; set; }//建立時間
        public DateTime UpdateDateTime { get ; set; }//修改時間
    }
}
