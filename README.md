# Ghost Typist

A minimal Windows desktop app that simulates human typing by sending keystrokes to the active window.

Type or paste text, load a `.txt` file, click **Digitar Texto**, and Ghost Typist types each character for you — useful when an application does not accept paste but does accept keyboard input.

## Features

- Multiline text input
- Load text from `.txt` files
- Character-by-character typing via `SendKeys`
- Adjustable typing pace (default: 50 ms between keystrokes)

## Requirements

- Windows 10 or later
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Build

```powershell
git clone https://github.com/rodrigoathaydes/ghost-typist.git
cd ghost-typist
dotnet build COPYTYPE.sln -c Release
```

## Run

```powershell
dotnet run --project COPYTYPE/COPYTYPE.csproj -c Release
```

Or run the executable from:

```
COPYTYPE\bin\Release\net8.0-windows\COPYTYPE.exe
```

## Usage

1. Open Ghost Typist.
2. Paste text into the box, or click **Carregar de Arquivo** to load a `.txt` file.
3. Click on the target application (editor, terminal, form field, etc.) so it has keyboard focus.
4. Return to Ghost Typist and click **Digitar Texto**.
5. Do not use the mouse or keyboard until typing finishes.

## Important notes

- **Focus matters:** keystrokes go to whichever window is active when typing starts.
- **Special characters:** `SendKeys` has limitations with some symbols and non-ASCII characters.
- **Security:** this tool sends real keyboard input. Only use it with text you trust, on applications you control.
- **Speed:** edit the delay in `Form1.cs` (`Thread.Sleep(50)`) to type faster or slower.

## Project structure

```
ghost-typist/
├── COPYTYPE.sln
└── COPYTYPE/
    ├── COPYTYPE.csproj
    ├── Form1.cs          # Main UI and typing logic
    └── Program.cs
```

## Author

Rodrigo Athaydes — [github.com/rodrigoathaydes](https://github.com/rodrigoathaydes)