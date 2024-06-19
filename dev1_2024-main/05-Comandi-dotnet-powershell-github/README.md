# I PRINCIPALI COMANDI DOTNET

- dotnet new (per creare un nuovo progetto)
- dotnet new console (per creare un nuovo progetto console)
- dotnet new webapp (per creare un nuovo progetto web)
- dotnet new sln (per creare una nuova soluzione)
- dotnet new classlib (per creare una nuova libreria di classi)
- dotnet new mvc (per creare un nuovo progetto MVC)

- dotnet restore (per ripristinare i pacchetti NuGet)
- dotnet build (per compilare il progetto)
- dotnet run (per eseguire il progetto)
- dotnet test (per eseguire i test)
- dotnet publish (per pubblicare il progetto)

- dotnet add reference (per aggiungere un riferimento ad un progetto)
- dotnet add package (per aggiungere un pacchetto NuGet)
- dotnet add sln (per aggiungere un progetto alla soluzione)
- dotnet add webapp (per aggiungere un progetto web alla soluzione)
- dotnet add mvc (per aggiungere un progetto MVC alla soluzione)

IMPORTANTE: per eseguire i comandi dotnet è necessario posizionarsi nella cartella del progetto

# I PRINCIPALI COMANDI POWERSHELL

- cd (per spostarsi in una cartella)
- cd .. (per spostarsi nella cartella superiore)
- mkdir (per creare una cartella)
- dir (per visualizzare i file e le cartelle)
- cls (per pulire la console)
- code . (per aprire Visual Studio Code)
- start . (per aprire Esplora File)
- start chrome "url" (per aprire Chrome)
- start firefox "url" (per aprire Firefox)
- start edge "url" (per aprire Edge)
- start iexplore "url" (per aprire Internet Explorer)
- start microsoft-edge:"url" (per aprire Edge Chromium)
- start microsoft-edge:"url" --inprivate (per aprire Edge Chromium in modalità InPrivate)


# I PRINCIPALI COMANDI GIT

- git init (per inizializzare un repository)
- git status (per visualizzare lo stato del repository)
- git add . (per aggiungere tutti i file alla staging area)
- git commit -m "messaggio" (per eseguire il commit)
- git log (per visualizzare la history dei commit)
- git checkout -b "nome-branch" (per creare un nuovo branch)
- git checkout "nome-branch" (per spostarsi su un branch esistente)
- git branch (per visualizzare i branch esistenti)
- git merge "nome-branch" (per eseguire il merge di un branch)
- git remote add origin "url" (per aggiungere un remote)
- git push -u origin master (per eseguire la prima push)
- git push (per eseguire una push)
- git pull (per eseguire una pull)
- git clone "url" (per clonare un repository)
- git commit --amend -m "Nuovo messaggio del commit" (Questo cambier� il messaggio dell'ultimo commit)
- git rebase -i HEAD~X (apre la procedura per cambiare un commmit specifico cambiare X con 3 per 3 commit precedenti)
Cambia pick in reword accanto al commit che vuoi modificare, poi salva e chiudi l'editor
Completa il rebase con git rebase --continue.
esegui git push origin <nome-del-branch> --force