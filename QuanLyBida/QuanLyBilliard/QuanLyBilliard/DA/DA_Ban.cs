﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBilliard.DTO;
using System.Data;

namespace QuanLyBilliard.DA
{
    class DA_Ban
    {
        LopDungChung ldc = new LopDungChung();
        public List<Ban> LayBan()
        {
            string sql = "SELECT * FROM BAN";
            DataTable dt = ldc.getDuLieu(sql);
            List<Ban> lst = new List<Ban>();
            foreach (DataRow row in dt.Rows)
            {
                Ban table = new Ban(row);
                lst.Add(table);
            }
            return lst;
        }

        public int BATBAN(Ban ban)
        {
            /*
                    Thực thi 1 procedure như sau, nhiệm vụ là thêm 1 hóa đơn với giờ chơi và trạng thái thanh toán bằng 0
                    sau đó update trạng thái bàn chuyển sang bật và lấy giờ vào cho bàn
                    CREATE PROCEDURE BATGIO
                    @id int
                    as
                    begin
                    insert into HOADON
                    values (@id,NULL,NULL,NULL,NULL,NULL,0,0);

                    update BAN 
                    set trangthai = 1, GIOVAO = GETDATE(), GIORA = NULL 
                    where ID_BAN = @id;
                    end
                 */
            string sql = "batgio " + ban.ID_Ban;
            return ldc.ExecuteNonQuery(sql);
        }

        public int TATBAN(Ban ban, HoaDon hd)
        {
            /*
                 CREATE PROCEDURE TATBAN
                    @id_ban int,
                    @id_hoadon int
                    as
                    begin
                    -- Cập nhật trạng thái cho bàn
                    UPDATE BAN
                    SET TRANGTHAI = 0,GIORA = getdate()
                    where ID_BAN = @id_ban
                    -- Tính tổng số giờ chơi của bàn có id_hoadon
                    UPDATE HOADON 
                    SET TONGGIOCHOI = (SELECT GIORA-GIOVAO FROM BAN WHERE ID_BAN =@id_ban) 
                    where ID_HOADON = @id_hoadon
                    end
                 */
            string sql = "TATBAN " + ban.ID_Ban + "," + hd.ID_HoaDon;
            return ldc.ExecuteNonQuery(sql);
        }
    }
}
