using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
class vehicle
{
    public String tenxe { get; set; }
    public Int16 namsx { get; set; }
    public string hangxe { get; set; }
    public double gia { get; set; }
    public void chay()
    {
        Console.WriteLine("Chạy trên đường");
    }
    public void xuat()
    {
        Console.WriteLine("Tên: " + tenxe);
        Console.WriteLine("Năm sản xuất: "+ namsx);
        Console.WriteLine("Hãng:"+ hangxe);
        Console.WriteLine("Giá xe:" + gia);
    }
    public void nhap()
    {
        Console.WriteLine("nhập tên xe:");
        tenxe = Convert.ToString(Console.ReadLine());
        Console.WriteLine("nhập năm sản xuất:");
        namsx = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("nhập hãng xe");
        hangxe = Convert.ToString(Console.ReadLine());
        Console.WriteLine("nhập giá xe:");
        gia = Convert.ToDouble(Console.ReadLine());
    }

    public vehicle()
    {
    }
}
class car: vehicle
{
    public  Int16 soNguoiCho { get; set; }
    public void xuat()
    {
        Console.WriteLine("     Xe hơi:");
        base.xuat();
        Console.WriteLine("Số người có thể chở:  " + soNguoiCho);
    }
    public void nhap()
    {
        base.nhap();
        Console.WriteLine("nhập số người có thể chở:");
        soNguoiCho  = Convert.ToInt16(Console.ReadLine());
    }
    public void choNguoi()
    {
        Console.WriteLine("chở người đi chơi");
    }
    public car()
    {
    }
}
class truck : vehicle
{
    public Int32 taiTrong { get; set; }
    public String chu { get; set; }
    public void xuat()
    {
        Console.WriteLine("Xe tải:");
        base.xuat();
        Console.WriteLine("Tải trọng: " + taiTrong);
        Console.WriteLine("Chủ: " + chu);

    }
    public void nhap()
    {
        base.nhap();
        Console.WriteLine("nhập tải trọng :");
        taiTrong = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("nhập chủ :");
        chu = Convert.ToString(Console.ReadLine());
    }
    public void choHang()
    {
        Console.WriteLine("chở hàng nặng");
    }
    public truck(){
        }
}

class Program
{

    static void Main()
    {
        var xehoi = new List<car>
        {
            new car {tenxe="AMG",namsx=2020, hangxe="MEC",gia=300000},
            new car {tenxe="C200",namsx=1890, hangxe="MEC",gia=200000},
            new car {tenxe="E100",namsx=1910, hangxe="MEC",gia=6000},
            new car {tenxe="R8",namsx=2022, hangxe="BMW",gia=350000},
            new car {tenxe="Q5",namsx=2020, hangxe="BMW",gia=240000},
            new car {tenxe="VF8",namsx=2022, hangxe="VINFAT",gia=90000},
            new car {tenxe="VF9",namsx=2023, hangxe="VINFAT",gia=150000},
        };

        var listgiaxe = from item in xehoi where item.gia>=100000 && item.gia<=250000 select item;
        //in xe có giá từ 100000 đến 250000
        Console.WriteLine("-----Xe có giá từ 100000 đến 250000");
        foreach (var item in listgiaxe)
        {
            Console.WriteLine(item.tenxe+" ,"+ item.namsx+" ,"+item.hangxe+" ,"+item.gia);
        }

        var listnamsx = from item in xehoi where item.namsx>1990 select item;
        //in xe có năm sản xuất >1990
        Console.WriteLine("----- Xe có năm sản xuất >1990: ");
        foreach (var item in listnamsx)
        {
            Console.WriteLine(item.tenxe + " ," + item.namsx + " ," + item.hangxe + " ," + item.gia);
        }


        var nhomxe  = xehoi
        .GroupBy(xe => xe.hangxe)
        .Select(group => new
        {
            hangxe  = group.Key,
            tonggia = group.Sum(xe => xe.gia)
        });
        Console.WriteLine("-----Tổng giá xe các loại:");
        foreach (var item in nhomxe)
        {
            Console.WriteLine( item.hangxe + " :" + item.tonggia);
        }

        var xetai = new List<truck>
        {
            new truck {tenxe="G55",namsx=2010, hangxe="HONDA",gia=300000,chu="Thai Binh"},
            new truck {tenxe="X8",namsx=2024, hangxe="HUYNDAI",gia=200000,chu="Thai Binh"},
            new truck {tenxe="Z9",namsx=2024, hangxe="HUYNDAI",gia=900000,chu="ABC"},
            new truck {tenxe="K3",namsx=2020, hangxe="HONDA",gia=350000,chu="ABC"},
            new truck {tenxe="ZX",namsx=2021, hangxe="HUYNDAI",gia=150000,chu="XYZ"},


        };
        var newest = (from item in xetai
                         orderby item.namsx descending
                         select item.namsx).FirstOrDefault();
       
        var listsapxenam = from item in xetai
                            where item.namsx == newest
                            select item;
        Console.WriteLine("-----Xe mới nhất :");
        foreach (var item in listsapxenam)
        {
            Console.WriteLine(item.tenxe + " ," + item.namsx + " ," + item.hangxe + " ," + item.gia+" ,"+item.chu);
        }


        Console.WriteLine("-----Tên các công ty chủ quản");
        var cty = xetai
           .GroupBy(xe => xe.chu)
           .Select(group => new
           {
               chu = group.Key,
           
           });
        foreach (var item in cty)
        {
            Console.WriteLine(item.chu);
        }


        Console.ReadLine();
    }
}