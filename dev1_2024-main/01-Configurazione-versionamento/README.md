# GIT E GITHUB IN VISUAL STUDIO CODE

- loggati su GIT

  **git config --global user.email "you@example.com"**
  **git config --global user.name "Your Name"**

  - per verificare che effettivamente sia stato riconosciuto l'utente digitare il comando
 
  **git config user.name**
  o
  **git config user.email**

- genera il token con il pannello di controllo di GITHUB nella sezione Developer settings

- scegli tra gli scope disponibili cioè le funzionalità alle quali avrà accesso il nostro profilo GITHUB

- Utilizza il comando **gh auth login** in visual studio code e segui la procedura

# CREARE UN REPOSITORY

- crea il repository con Github (remoto)

>Passaggi:

…or create a new repository on the command line

- echo "# prova_da-cancellare" >> README.md (crea il file README.md)
- git init (inizializza il repository locale)
- git add README.md (aggiunge il file README.md alla staged area)
- git commit -m "first commit" (crea il primo commit)
- git branch -M main (crea il branch main)
- git remote add origin https://github.com/delectablerec/prova_da-cancellare.git (aggiunge l'origine remota)
- git push -u origin main (effettua il push)

…or push an existing repository from the command line

- git remote add origin https://github.com/delectablerec/prova_da-cancellare.git (aggiunge l'origine remota)
- git branch -M main (crea il branch main)
- git push -u origin main (effettua il push)

>Il primo **passaggio** si effettua così:


- crea un repository (locale ) attraverso il comando **git init**

- aggiungi il files readme con il comando **git add README.md**

- fai il primo commit che significa creare un nuovo salvataggio del documento staged **git commit -m "first commit"**

- fai **git status** per vedere lo stato, sarai on branch master

- crea il branch main e cioè il ramo principale nel quale avverranno le modifiche **git branch -M main**

> (git branch nomeBranch permette di spostarsi da un branch all'altro, qua stiamo creando il main rinominando il master)

- aggiungi l'origine remota cioè la destinazione dei nostri commit

**git remote add origin https://github.com/delectablerec/java-fullstack-assign.git**

- lancia il comando per caricare il contenuto aggiunto alla staged area in questo caso il README.md
  **git push -u origin main**

# File .gitignore

Il files .gitignore permette di escludere dal versionamento alcuni files o cartelle selettivamente

Un esempio di file .gitignore:
```markdown
# See https://help.github.com/articles/ignoring-files/ for more about ignoring files

# dependencies
/node_modules
/bin
/obj
/.pnp
.pnp.js

# testing
/coverage
/xx-Esercitazioni

# production
/build

# misc
.DS_Store
.env.local
.env.development.local
.env.test.local
.env.production.local

npm-debug.log*
yarn-debug.log*
yarn-error.log*
```

# comandi GIT e GITHUB

**git --version**

(dovrebbe visualizzare questo) git version 2.40.0.windows.1

- git init
inizializza il reposito locale

- git reset
è il comando contrario che permette di deinizializzare

- ls
ls elencherà i file nella directory con la data di creazione

- git status
git status verifica quali files sono compresi nel controllo versione 

- git add <file> (es. git add index.html)
git add index.html aggiunge al controllo della versione un file specifico e permette anche di aggiornare il controllo della versione

- git rm --cached <file> (es. git rm --cached index.html)
rm --cached esclude il files scelto dal controllo versione

**I file nella cartella del repository Git possono trovarsi in uno dei 2 stati seguenti**

>Tracciato: file di cui Git è a conoscenza e che vengono aggiunti al repository

>Untracked - file che si trovano nella directory di lavoro, ma non aggiunti alla cartella deposito

- git add --all
permette di aggiungere alla staged area più files contemporaneamente

- git restore <file> (git restore index.html)
ripristina lo stato precedente del file prima della modifica

- git commit-m "message"
permette di creare un punto di salvataggio come una fotografia del codice ed il messaggio indica suggerimenti riguardanti la modifica

- il comando --short
permette di avere un feedback più sintetico

- il flag -a permette di effettuare il commit di più files contemporaneamente e di editare direttamente il messaggio di commit nella console
per farlo deve essere stata effettuata una modifica ad almeno un file

**Nota: I flag di stato brevi sono**

- ?? - File non tracciati
- A - File aggiunti allo stage
- M - File modificati
- D - File eliminati

**git commit -a**

per uscire dell'inserimento del messaggio premere esc

per non salvare le modifiche :qa!

per salvare le modifiche :wq

per uscire :q

- git log
permette di consultare i commit effettuati

- git --help glossary
permette di visualizzare la pagina online con la documentazione

- git --help tutorial
permette di visualizzare la pagina online con tutorial

- git help --all
fa vedere tutti i comandi e bisogna ricordarsi di premere la freccia in basso per vederli

[PAGINA alla quale consultare i comandi principali](https://www.w3schools.com/git/git_help.asp?remote=github)

- git branch <nomedelbranch>

permette di creare un ramo che si differenzia dal branch master

- git checkout <nomedelbranch> oppure git switch <nomedelbranch>
permette di verificare in quale branch mi trovo attualmente

- git merge <nomedelbranchdaunirealmaster> (git merge readme)
permette di unire i branch al branch principale master Git vede questo come una continuazione del master

FINO A QUESTO PUNTO ABBIAMO LAVORATO CON COMANDI SUL REPOSITORY LOCALE

REPOSITORY REMOTO

Per prima cosa creare il repository remoto tramite il pannello di controllo su GitHub

- git remote add origin url <origin>
impostare un origine remota sulla quale effettuare i push

- git remote remove origin
resettare un origine

- git remote -v
per consultare l'origine remota attuale

effettuare il push
- git push -u origin

# git merge

Il comando "git merge" viene utilizzato in Git per combinare le modifiche di due o più branch diversi.

Ecco come utilizzare il comando "git merge":

Assicurati di trovarti nel branch di destinazione es MAIN in cui vuoi incorporare le modifiche egli altri branch.

 Ad esempio, se vuoi incorporare le modifiche del branch "tiziano" nel branch "main", devi prima passare al branch "main" utilizzando il comando "git checkout main".

Utilizza il comando "git merge <branch>" per incorporare le modifiche del branch specificato nel branch di destinazione.

Ad esempio, se vuoi incorporare le modifiche del branch "tiziano" nel branch "main", digita "git merge tiziano".

In alcuni casi, può essere necessario risolvere i conflitti di merge manualmente prima di poter completare il merge.

Se il merge ha successo, Git creerà un nuovo commit che incorpora le modifiche dei due branch. È possibile visualizzare l'elenco dei commit utilizzando il comando "git log".

Dopo aver completato il merge, puoi caricare le modifiche sul repository remoto utilizzando il comando "git push"

# git pull

Il comando "git pull" viene utilizzato in Git per scaricare le modifiche dal repository remoto e incorporarle nel branch locale corrente.

Ecco come utilizzare il comando "git pull":

Assicurati di trovarti nel branch locale in cui desideri incorporare le modifiche del repository remoto. Ad esempio, se desideri aggiornare il branch "mainj", devi prima passare al branch "main" utilizzando il comando "git checkout main".

Utilizza il comando "git pull" per scaricare le modifiche dal repository remoto e incorporarle nel branch locale corrente. Git cercherà di combinare automaticamente le modifiche scaricate con le modifiche locali presenti nel branch corrente.
In caso di conflitti, dovrai risolvere manualmente i conflitti prima di poter completare il pull.

Dopo aver eseguito il comando "git pull", Git creerà un nuovo commit che incorpora le modifiche scaricate dal repository remoto.

È possibile visualizzare l'elenco dei commit utilizzando il comando "git log".

Se necessario, puoi caricare le modifiche incorporate nel repository remoto utilizzando il comando "git push"