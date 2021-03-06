
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using SqlKata.Execution;
namespace EonBotzLibrary
{
    public class schedule
    {

        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;

        public List<string> datafill = new List<string>();
        public List<string> datafillroom = new List<string>();
        public List<string> datafillcourse = new List<string>();

        public string timediff { set; get; }
        public string subjcode { set; get; }
        public string subjTitle { set; get; }
        public string roomdesc { set; get; }
        public string date { set; get; }
        public string timeStart { set; get; }
        public string timeEnd { set; get; }
        public string maxStudent { set; get; }
        public string status { set; get; }
        public string roomid { set; get; }
        public string course { set; get; }
        public string timeending { set; get; }
        public string timedifftuesday { set; get; }
        public string textValue { set; get; }


        public DataTable dt = new DataTable();
        public DataTable dtFilter = new DataTable();

        private DataSet ds = new DataSet();
        public void times()
        {
            conn = connect.getcon();
            conn.Open();
            //cmd = new MySqlCommand(" select timeend from schedule where roomid = '" + roomid + "'and date regexp '[" + date + "]' and timestart between '"+timeStart+"'and'"+timeEnd+"'", conn);
            cmd = new MySqlCommand(" select timeend from schedule where status = 'available' and roomid = '" + roomid + "'and date regexp '[" + date + "]' and timestart < '" + timeEnd + "' and timeEnd > '" + timeStart + "'", conn);
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    timediff = mdr[0].ToString();
                }
                conn.Close();
            }
        }
        public void tuesday()
        {
            timediff = "aa";
        }
        public void Schedule()
        {
            conn = connect.getcon();
            conn.Open();

            datafill.Clear();

            using (cmd = new MySqlCommand("SELECT subjectcode FROM subjects", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafill.Add(mdr[0].ToString());
                }
                conn.Close();
            }

            conn = connect.getcon();
            conn.Open();

            datafillroom.Clear();

            using (cmd = new MySqlCommand("SELECT name FROM rooms", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafillroom.Add(mdr[0].ToString());
                }
                conn.Close();
            }

            conn = connect.getcon();
            conn.Open();

            datafillcourse.Clear();

            using (cmd = new MySqlCommand("SELECT coursecode FROM coursecode", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafillcourse.Add(mdr[0].ToString());
                }
                conn.Close();
            }

        }
        public void viewroomNum()
        {

            status = "available";

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select roomID from rooms where name = '" + roomdesc + "'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                roomid = mdr[0].ToString();
            }
            conn.Close();
        }
        public void viewCourseID()
        {

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select courseID from coursecode where courseId = '" + course + "'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                course = mdr[0].ToString();
            }
            conn.Close();


        }

        public void insertSched()
        {
            viewroomNum();

            viewCourseID();

            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("INSERT INTO schedule(subjectCode,subjectTitle,roomid,date,timestart,timeend,status,maxStudent, courseCode)VALUES(" +
                "@subjcode,@subjectTitle,@roomid,@date,@timestart,@timeend,@status,@maxStudent,@course)", conn))
            {
                cmd.Parameters.AddWithValue("@subjcode", subjcode);
                cmd.Parameters.AddWithValue("@subjectTitle", subjTitle);
                cmd.Parameters.AddWithValue("@roomid", roomid);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@timestart", timeStart);
                cmd.Parameters.AddWithValue("@timeend", timeEnd);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@maxStudent", maxStudent);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }
        public void Viewdescription()
        {
            conn = connect.getcon();
            conn.Open();
            using (cmd = new MySqlCommand("select subjectTitle from subjects where subjectcode =@subjCode", conn))
            {
                cmd.Parameters.AddWithValue("@subjCode", subjcode);
                mdr = cmd.ExecuteReader();
                mdr.Read();
                if (mdr.HasRows)
                {
                    subjTitle = mdr[0].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
        public void viewsched()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.schedID, a.subjectCode, a.subjectTitle, c.name ,a.courseCode,a.date,a.maxStudent - count(b.studentSchedID),a.timeStart,a.timeEnd,a.status from schedule a   left join rooms c on c.roomId = a.roomId  left join  studentSched b on b.schedid regexp a.schedid group by a.schedid", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();

                dt.Columns.Add("SchedID");
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("SubjTitle");
                dt.Columns.Add("RoomID");
                dt.Columns.Add("CourseID");
                dt.Columns.Add("date");
                dt.Columns.Add("maxStudent");
                dt.Columns.Add("time start");
                dt.Columns.Add("time end");
                dt.Columns.Add("status");

                while (mdr.Read())
                {
                    string foo = mdr[5].ToString(), bar = string.Empty;

                    foreach (char c in foo)
                    {
                        if (c == '1')
                        {
                            bar += "M";
                        }
                        else if (c == '2')
                        {
                            bar += "T";
                        }
                        else if (c == '3')
                        {
                            bar += "W";
                        }
                        else if (c == '4')
                        {
                            bar += "Th";
                        }
                        else if (c == '5')
                        {
                            bar += "F";
                        }
                        else if (c == '6')
                        {
                            bar += "S";
                        }
                    }

                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), bar, mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString());
                }
            }
        }
        public void filterSched()
        {
            conn = connect.getcon();
            conn.Open();

            dtFilter.Clear();
            using (cmd = new MySqlCommand("select a.schedID, a.subjectCode, a.subjectTitle, c.name ,a.courseCode,a.date,a.maxStudent - count(b.studentSchedID),a.timeStart,a.timeEnd,a.status from schedule a   left join rooms c on c.roomId = a.roomId  left join  studentSched b on b.schedid regexp a.schedid where a.subjectcode like'"+textValue+"%' group by a.schedid", conn))
            //using (cmd = new MySqlCommand("SELECT  a.schedID, a.subjectCode, a.subjectTitle, b.name, a.courseCode, a.date, a.maxStudent - count(b.studentSchedID), a.timeStart, a.timeEnd, a.status FROM schedule a, rooms b where a.roomID = b.roomiD and a.subjectTitle LIKE '%" + textValue + "%'  OR  a.subjectCode LIKE '%" + textValue + "%' and a.roomId = b.roomid and a.status ='available' group by a.schedid", conn))
            //   using (cmd = new MySqlCommand("select a.schedID, a.subjectCode, a.subjectTitle, c.name ,a.courseCode,a.date,a.maxStudent - count(b.studentSchedID),a.timeStart,a.timeEnd,a.status from schedule a left join rooms c on c.roomId = a.roomId and a.status = 'available' left join  studentSched b on b.schedid regexp a.schedid group by a.schedid", conn))
            {
                mdr = cmd.ExecuteReader();

                dtFilter.Columns.Clear();

                dtFilter.Columns.Add("SchedID");
                dtFilter.Columns.Add("SubjectCode");
                dtFilter.Columns.Add("SubjTitle");
                dtFilter.Columns.Add("RoomID");
                dtFilter.Columns.Add("CourseID");
                dtFilter.Columns.Add("date");
                dtFilter.Columns.Add("maxStudent");
                dtFilter.Columns.Add("time start");
                dtFilter.Columns.Add("time end");
                dtFilter.Columns.Add("status");

                while (mdr.Read())
                {
                    string foo = mdr[5].ToString(), bar = string.Empty;

                    foreach (char c in foo)
                    {
                        if (c == '1')
                        {
                            bar += "M";
                        }
                        else if (c == '2')
                        {
                            bar += "T";
                        }
                        else if (c == '3')
                        {
                            bar += "W";
                        }
                        else if (c == '4')
                        {
                            bar += "Th";
                        }
                        else if (c == '5')
                        {
                            bar += "F";
                        }
                        else if (c == '6')
                        {
                            bar += "S";
                        }
                    }

                    dtFilter.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), bar, mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString());
                }
            }
        }
    }
}