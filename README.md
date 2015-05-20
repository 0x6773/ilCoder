# ilCoder

## About

An easy way to see IL Code of your C# Code.
To do this it uses Mono.Cecil library.

## How to use?

Build the project using MonoDevelop or build in Terminal using ```xbuild``` 
Nice Method to Use :
```
./ilCoder.exe -f path/to/exe/or/dll/file -c class/name -m method/name -o name/of/output/file
#
# IL Code
#
```
* You will get IL code only if you input data correct.

Output File is optional, if not given will produce output on screen.

Good Method to Use : 
```
./ilCoder.exe
Enter path to Binary File : path/to/exe/or/dll/file
Enter the name of class : class/name
Enter the name of method : method/name
Enter the path to output file (leaving it will give output on screen) : name/of/output/file
```

##[```Report Issues```](https://github.com/mafiya69/ilCoder/issues)
