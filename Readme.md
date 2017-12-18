## To-do
### Belum dikerjakan

### Sedang dikerjakan

### Sudah dikerjakan
- [x] implementasi composite pattern
- [x] buat text
- [x] implementasi state pattern (preview, edit, static state)
- [x] buat bentuk primitif
- [x] buat obyek garis
- [x] buat bentuk primitif turunan dari kelas bentuk generik
- [x] tambahin toolbar untuk milih obyek apa yang digambar
- [x] buat supaya obyek di kanvas bisa dipindah
- [x] buat ellipse
- [x] tambahin menubar untuk opsi undo - redo
- [x] buat obyek bisa digambar dari arah mana saja (bukan cuma dari kiri atas ke kanan bawah)
- [x] Hapus object
- [x] implementasi memento pattern
- [x] buat obyek bisa diresize (sort of)
- [x] buat obyek aktor

# Use Case Diagramming Tool
Aplikasi ini merupakan tools untuk membuat diagram <b>Use Case</b>. Fitur aplikasi ini adalah dapat memilih komponen diagram use case dengan cara drag and drop.

- Programming Language: C#
- Design Pattern: State Pattern, Memento Pattern, Composite Pattern

## Aturan Workflow
Repositori ini menggunakan `centralized workflow` dengan menggunakan branch `master` sebagai centralnya.

Hal yang diperhatikan ketika melakukan melakukan `push`:
- Pastikan tidak ada `code error` pada file yang dicommit. Kalau ada dan belum disolve dicomment saja codenya.
- Berikan keterangan yang informatif pada `commit message` terkait perubahan yang dilakukan.
- Sebelum melakukan perubahan pada code, lakukan terlebih dahulu `fetch` atau `pull` agar mendapatkan code yang update dan meminimalisir conflict.
- Setelah selesai melakukan perubahan segera lakukan `commit` dan `push` ke remote repository. Perhatikan poin pertama.

## Aturan Penulisan Kode
- Nama class dan method menggunakan `PascalCasing` contohnya : 
```C
public class ClassName()
{
    public void MethodName()
    {
        //...
    }
}
```
- Nama variabel dan parameter menggunakan `CamelCase`
contohnya :
```C
public class ClassName()
{
    public void MethodName(ParameterClass parameterName)
    {
        int variableName;
        //...
    }
}
```
- Penamaan kelas menggunakan `kata benda`
- Untuk class interface penamaannya menggunakan penambahan prefix `I`
- Penamaan File menggunakan `PascalCasing` dan merepresentasikan isi file tersebut.
- Penulisan `bracket` sejajar vertical dengan code.
contohnya:
```c
class Program
{
    static void Main(string[] args)
    {
    }
}
```
- Deklarasi nama variable dilakukan diawal class. Dengan variabel static diposisi paling atas terlebih dahulu.
contohnya:
```c
public class Account
{
    public static string BankName;
    public static decimal Reserves;
 
    public string Number {get; set;}
    public DateTime DateOpened {get; set;}
    public DateTime DateClosed {get; set;}
    public decimal Balance {get; set;}
 
    // Constructor
    public Account()
    {
        // ...
    }
}
```
