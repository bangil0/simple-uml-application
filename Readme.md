## To-do
### Belum dikerjakan
- [ ] buat ellipse
- [ ] buat text
- [ ] buat supaya obyek di kanvas bisa dipindah
- [ ] tambahin menubar untuk opsi undo - redo
- [ ] implementasi composite pattern
- [ ] implementasi memento pattern

### Sedang dikerjakan

### Sudah dikerjakan
- [x] implementasi state pattern (preview, edit, static state) --- Nia
- [x] buat bentuk primitif --- Nia
- [x] buat obyek garis --- Val
- [x] buat bentuk primitif turunan dari kelas bentuk generik --- Salman
- [x] tambahin toolbar untuk milih obyek apa yang digambar --- Salman

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
public class ClassName(){
    public void MethodName()
    {
        //...
    }
}
```
- Nama variabel dan parameter menggunakan `CamelCase`
contohnya :
```C
public class ClassName(){
    public void MethodName(ParameterClass parameterName)
    {
        int variableName;
        //...
    }
}
```
- Penamaan kelas menggunakan `kata benda`
- Untuk class interface penamaannya menggunakan penambahan prefix `i`
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
