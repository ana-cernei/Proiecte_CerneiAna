\#### Lucrare de licență - Combaterea Fobiilor la Copii cu Dizabilități folosind jocuri serioase în VR





\*\*Autor:\*\* Ana Maria Cernei  

\*\*Coordonator:\*\* Prof. Dr. Marc Frîncu  

\*\*Universitatea de Vest din Timișoara\*\*



---



\## Descriere generală



Această aplicație de realitate virtuală (VR) este concepută pentru a ajuta copiii cu dizabilități, în special cei diagnosticați cu TSA (tulburare din spectrul autist), să își depășească frica de câini (cinofobie), prin expunere treptată într-un mediu familiar, sigur și controlat.



Aplicația a fost dezvoltată și testată terapeutic cu un minor cu TSA și retard mintal ușor. Sunt disponibile \*\*4 versiuni terapeutice\*\*, care cresc gradual nivelul de interactivitate.



---



\## Versiuni aplicație



| Versiune | Descriere |

|----------|-----------|

| \*\*Project\_Phobia\_V1\*\* | Observare pasivă a câinelui virtual. Fără sunete sau interacțiuni. Doar acomodare vizuală. |

| \*\*Project\_Phobia\_V2\*\* | Interacțiune indirectă: un buton VR declanșează comportamente prietenoase ale câinelui. |

| \*\*Project\_Phobia\_V3\*\* | Mini-joc: apăsarea butonului → acțiuni ale câinelui + recompense vizuale (confetti, scor, stele). |

| \*\*Project\_Phobia\_V4\*\* | Interacțiune directă: utilizatorul aruncă mingea sau piaptănă câinele. Câinele răspunde cu reacții animate, fiind intergrat sistemul de recompensă anterior |



\*\*Instrucțiuni de folosire și context aplicații\*\*



\*Prima versiune\* 

&nbsp;Utilizatorul poate observa scena și animațiile câinelui , se poate mișca în scena prin mers sau prin folosirea de controllere.



\*A doua versiune\*

&nbsp;Utilizatorul poate apasă butonul folosind controllere (buttonul de trigger) sau VR hands (metoda de pinch - prin întinderea mâinii spre butonul UI și crearea gestului de ciupire). După apăsare, se activează reacția câinelui - acesta privește jucătorul timp de 5 secunde fiind adăugate o animație de dat din coadă și sunet de lătrat. 



\*A treia versiune\*

&nbsp;Această versiune se bazează pe cea anterioară, apăsarea butonului fiind la fel, adăugând un sistem de recompensă. 

Pe tabela de joc se regăsesc instrucțiuni despre ce trebuie făcut(apăsare buton), crește scorul și apar progresiv stele. 

La trei apăsari de butonul apare pe tabela o încurajare și deasupra sa un efect de confetti. 

După un timp, se resetează jocul, iar utilizatorul începe procesul din nou.



\*A patra versiune\*

Versiunea aceasta include două jocuri.



\### Jocul 1 – Pieptănarea câinelui și recompensa



Utilizatorul citește instrucțiunile pe tabela de joc aflată deasupra mesei.  

Acesta trebuie să pieptene câinele German Sheperd prezent și în scenele anterioare.



Utilizatorul poate să ia peria în mână folosind controllerul drept, ținând controller-ul aproape de perie.  

Apoi piaptănă câinele atunci când se apropie suficient (triggerul se activează când peria atinge collider-ul câinelui).  

Sistemul de recompensă este același ca în versiunea anterioară.  

Peria se pune la loc pe masă apăsând tasta \*\*B\*\* de pe controller.



---



\### Jocul 2 – Aruncarea mingii



Utilizatorul poate să ia mingea de pe masă folosind opțiunea de \*Grab\*, prin apăsarea butonului lateral de pe controller.  

Apoi aruncă mingea simulând gestul și eliberând butonul.  

Câinele Corgi aleargă după minge și o aduce aproape de punctul de start al utilizatorului.  

Jocul se poate repeta de mai multe ori în același mod.



---





\## Structura fișierelor



Fișierele mari (modele 3D, sunete, animații, texturi) nu sunt incluse în acest repository GitLab, din cauza limitării de spațiu și pentru a păstra un proiect curat și ușor de analizat.  

Accesează fișierele necesare rulării aplicației din Google Drive:  

🔗 \[Link către Google Drive – Assets și apk-urile versiunilor aplicației](https://drive.google.com/drive/folders/1qwTC4fGoUbzXw\_z5jMypyvkq\_D\_ekL3z)



\### Structura conținutului din Drive



\- `Assets\_V1/`, `Assets\_V2/`, ... – fiecare conține folderul `Assets/` complet pentru versiunea respectivă  

\- `apk\_builds/` – fișiere `.apk` gata de instalare pe \*\*Meta Quest 2\*\*



---



\## Cum folosești proiectul complet



1\. Clonează sau descarcă acest repository.

2\. Din Google Drive, descarcă folderul `Assets/` corespunzător versiunii tale.

3\. Copiază folderul `Assets/` din Drive \*\*peste cel existent în proiectul local\*\*  

&nbsp;  (va înlocui `scripturi/` și `scena/`, dar codul rămâne același).

4\. Deschide proiectul cu Unity (\*\*versiunea 2022.3.22f1 LTS\*\*) și urmează pașii din secțiunea \*Setup în Unity\*.

5\. Pentru testare pe dispozitiv, instalează `.apk` din Drive sau generează unul nou din Unity.

---



\## ❗ Notă importantă



\- Scena din `Assets/Scenes/` este inclusă \*\*doar pentru referință\*\* – nu va funcționa complet fără asseturile din Drive.

\- Script-urile C# se regăsesc integral în folderul `Assets/Scripts/`.

\- Asigură-te că \*\*înlocuiești complet\*\* folderul `Assets/` din GitLab local cu cel descărcat din Drive, altfel scenele nu vor fi funcționale.





\## Setup în Unity



\###  Tehnologii utilizate



\- \*\*Unity Hub\*\* cu \*\*Unity 2022.3.22f1 LTS\*\*

\- \*\*Android Build Support\*\* (cu SDK/NDK și OpenJDK)

\- \*\*Cască VR Meta Quest 2\*\*

\- \*\*Meta Quest Developer Hub (MQDH) 5.2.1\*\*  

&nbsp; ↳ \[Descarcă de aici](https://developer.oculus.com/downloads/package/meta-quest-developer-hub/)

\- \*\*Meta Horizon\*\* (versiunea aplicației testată: \*\*323.0.0.16.109\*\*)

\- \*\*Meta Quest Casting\*\* pentru vizualizarea sesiunilor VR

\- \*\*Visual Studio 2022\*\* (pentru scrierea codului C#)

\- \*\*C#\*\* (Unity Scripting API)



\### Pachete necesare:



Asigură-te că ai instalat în `Package Manager`:



\- \*\*XR Plugin Management\*\*

\- \*\*Oculus XR Plugin\*\*

\- \*\*OpenXR Plugin\*\*

\- \*\*XR Interaction Toolkit\*\*

\- \*\*XR Hands (opțional)\*\*

\- \*\*Input System\*\*

\- \*\*URP + Post-Processing\*\*



> \*Project-ul pornește din VR Core Template cu URP configurat.\*



\### Configurare Project Settings:



1\. `Edit > Project Settings > XR Plugin Management`:

&nbsp;  - Activează \*\*Oculus\*\* pentru Android

&nbsp;  - Activează \*\*OpenXR\*\* (dacă folosești Interaction Toolkit)



2\. `Player Settings > Other Settings`:

&nbsp;  - Setați:

&nbsp;    - `Color Space`: \*\*Linear\*\*

&nbsp;    - `Graphics API`: \*\*Vulkan\*\* sau \*\*OpenGLES3\*\*

&nbsp;    - `Minimum API Level`: \*\*Android 10.0 (API 29)\*\*



3\. `Build Settings`:

&nbsp;  - Platformă: \*\*Android\*\*

&nbsp;  - Setați scenele corecte în `Scenes in Build` 

&nbsp;  - Bifați `Development Build` doar pentru test



---



\## Interacțiuni implementate



\- \*\*Buton interactiv\*\* – pornește comportamente ale câinelui

\- \*\*NavMeshAgent\*\* – navigație automată a câinelui

\- \*\*Animator Controller\*\* – comportamente animate: mers, mâncat, alergat, stat, dă din coadă

\- \*\*Sistem scor + iconițe (stea, inimă) + confetti\*\*

\- \*\*Trigger-uri pentru minge și perie\*\*

\- \*\*Sunete realiste\*\* pentru lătrat blând, respirație, mâncat, alergat



---



\##  Build \& testare pe Meta Quest 2



\### 1. Activează Developer Mode pe cască:



\- Descarcă aplicația \*\*Meta Horizon\*\* pe telefon (Android/iOS)

\- Creează cont Meta și adaugă casca

\- Accesează:

&nbsp; ```

&nbsp; Devices > Developer Mode > ON

&nbsp; ```



\### 2. Conectează casca prin USB-C



\- Activează „Allow USB debugging” în cască

\- În Windows, acceptă toate permisiunile



\### 3. Build `.apk` din Unity



1\. În Unity:

&nbsp;  - `File > Build Settings > Android`

&nbsp;  - Selectează scena curentă

&nbsp;  - Click `Build` și salvează fișierul `.apk`



2\. Instalează pe cască folosind:

&nbsp;  - \*\*Meta Quest Developer Hub\*\* (MQDH)- adaugă build-ul apk in secțiunea cu aplicațiile tale 

&nbsp;  - Sau terminal ADB:

&nbsp;    ```bash

&nbsp;    adb install nume\_aplicatie.apk

&nbsp;    ```



\### 4. Rularea aplicației și setări suplimentare 



\- Pune casca pe cap

\- Utilizatorul iși setează pe cască opțiunile pentru limita mediului de joc și nivelul podelei.(boundary și floor level din setări) 

Limita mediului trebuie să fie una rezonabilă, pentru a permite mișcarea în scenă a utilizatorului

\- Activează opțiunea de Hand tracking pentru folosirea de VR hands în jocuri(implementată în versiunile V2 -> v4)

\- Accesează:

&nbsp; ```

&nbsp; Apps > Unknown Sources > \[Numele aplicației]

&nbsp; ```



---



\## Asset-uri folosite



| Tip         | Link |

|-------------|------|

| Podea        | \[Stylized Textures](https://assetstore.unity.com/packages/2d/textures-materials/25-free-stylized-textures-grass-ground-floors-walls-more-241895) |

| Câine        | \[Animated Dogs – Bublisher](https://assetstore.unity.com/packages/3d/characters/animals/mammals/3d-stylized-animated-dogs-kit-284699) |

| Case         | \[Medieval Buildings](https://assetstore.unity.com/packages/3d/environments/historic/lowpoly-medieval-buildings-58289) |

| Farm assets  | \[Lite Farm Pack](https://assetstore.unity.com/packages/3d/environments/industrial/lite-farm-pack-low-poly-3d-art-by-gridness-243315) |

| Masă \& scaun | \[Outdoor Furniture](https://assetstore.unity.com/packages/3d/props/furniture/summer-open-air-table-and-chair-94677) |

| Perie        | \[Stylized Brush](https://assetstore.unity.com/packages/3d/props/stylized-brush-hair-310778) |

| Minge        | \[Low Poly Ball](https://assetstore.unity.com/packages/3d/low-polygon-soccer-ball-84382) |

| Bol          | \[Steel Bowl – Sketchfab](https://www.fab.com/listings/5b1ed861-f24e-4d6c-bdd7-1cd646938339) |



---



\## Sunete utilizate



\- Mâncat: \[Freesound](https://freesound.org/people/qubodup/sounds/741034/)

\- Respirație: \[Freesound](https://freesound.org/people/jayylls/sounds/654649/)

\- Lătrat blând: \[Freesound](https://freesound.org/people/Alex\_hears\_things/sounds/758868/)

\- Alergat: \[Freesound](https://freesound.org/people/ilmari\_freesound/sounds/585911/)



---



\## Recompense vizuale



\- Stea: \[Flaticon](https://www.flaticon.com/free-icon/star\_7269732)

\- Inimă: \[PNGTree](https://pngtree.com/freepng/beautiful-bright-red-heart\_6252575.html)

\- Confetti fluture-pentru sprite (în descrierea videoclipului): \[YouTube](https://www.youtube.com/watch?v=NNBkTTykXU0)



---



\## Observații finale



\- Fiecare versiune este \*\*autonomă\*\* și poate fi testată individual.

\- Se recomandă parcurgerea în ordine (V1 → V4) pentru a respecta progresia terapeutică.

\- Aplicațiile necesită conexiune la internet și nu colectează date personale.

\- Ideal de testat într-un mediu liniștit, cu prezența unui adult (mamă/terapeut).



---

\## Notă etică



Acest proiect a fost realizat în cadrul lucrării de licență și este bazat pe un caz real de terapie VR aplicată unui copil diagnosticat cu tulburare din spectrul autist și dizabilitate intelectuală ușoară.  



Pentru protejarea confidențialității, acest repository \*\*nu conține date personale, imagini, filmări sau informații medicale identificabile\*\*.  



Codul sursă este publicat exclusiv în scopuri academice și educaționale. Rezultatele testărilor sunt prezentate într-o formă \*\*generalizată și anonimizată\*\*, fără a compromite identitatea participantului.  



Proiectul respectă principiile etice în lucrul cu populații vulnerabile și aspectele LSEP aferente.



\## Contact



Pentru întrebări, instalare sau feedback:  

\*\*Ana Maria Cernei\*\* 

Contact: anicernei@gmail.com

---

&nbsp;Lucrare de licență - Combaterea Fobiilor la Copii cu Dizabilități folosind jocuri serioase în VR





\*\*Autor:\*\* Ana Maria Cernei  

\*\*Coordonator:\*\* Prof. Dr. Marc Frîncu  

\*\*Universitatea de Vest din Timișoara\*\*



---



\## Descriere generală



Această aplicație de realitate virtuală (VR) este concepută pentru a ajuta copiii cu dizabilități, în special cei diagnosticați cu TSA (tulburare din spectrul autist), să își depășească frica de câini (cinofobie), prin expunere treptată într-un mediu familiar, sigur și controlat.



Aplicația a fost dezvoltată și testată terapeutic cu un minor cu TSA și retard mintal ușor. Sunt disponibile \*\*4 versiuni terapeutice\*\*, care cresc gradual nivelul de interactivitate.



---



\## Versiuni aplicație



| Versiune | Descriere |

|----------|-----------|

| \*\*Project\_Phobia\_V1\*\* | Observare pasivă a câinelui virtual. Fără sunete sau interacțiuni. Doar acomodare vizuală. |

| \*\*Project\_Phobia\_V2\*\* | Interacțiune indirectă: un buton VR declanșează comportamente prietenoase ale câinelui. |

| \*\*Project\_Phobia\_V3\*\* | Mini-joc: apăsarea butonului → acțiuni ale câinelui + recompense vizuale (confetti, scor, stele). |

| \*\*Project\_Phobia\_V4\*\* | Interacțiune directă: utilizatorul aruncă mingea sau piaptănă câinele. Câinele răspunde cu reacții animate, fiind intergrat sistemul de recompensă anterior |



\*\*Instrucțiuni de folosire și context aplicații\*\*



\*Prima versiune\* 

&nbsp;Utilizatorul poate observa scena și animațiile câinelui , se poate mișca în scena prin mers sau prin folosirea de controllere.



\*A doua versiune\*

&nbsp;Utilizatorul poate apasă butonul folosind controllere (buttonul de trigger) sau VR hands (metoda de pinch - prin întinderea mâinii spre butonul UI și crearea gestului de ciupire). După apăsare, se activează reacția câinelui - acesta privește jucătorul timp de 5 secunde fiind adăugate o animație de dat din coadă și sunet de lătrat. 



\*A treia versiune\*

&nbsp;Această versiune se bazează pe cea anterioară, apăsarea butonului fiind la fel, adăugând un sistem de recompensă. 

Pe tabela de joc se regăsesc instrucțiuni despre ce trebuie făcut(apăsare buton), crește scorul și apar progresiv stele. 

La trei apăsari de butonul apare pe tabela o încurajare și deasupra sa un efect de confetti. 

După un timp, se resetează jocul, iar utilizatorul începe procesul din nou.



\*A patra versiune\*

Versiunea aceasta include două jocuri.



\### Jocul 1 – Pieptănarea câinelui și recompensa



Utilizatorul citește instrucțiunile pe tabela de joc aflată deasupra mesei.  

Acesta trebuie să pieptene câinele German Sheperd prezent și în scenele anterioare.



Utilizatorul poate să ia peria în mână folosind controllerul drept, ținând controller-ul aproape de perie.  

Apoi piaptănă câinele atunci când se apropie suficient (triggerul se activează când peria atinge collider-ul câinelui).  

Sistemul de recompensă este același ca în versiunea anterioară.  

Peria se pune la loc pe masă apăsând tasta \*\*B\*\* de pe controller.



---



\### Jocul 2 – Aruncarea mingii



Utilizatorul poate să ia mingea de pe masă folosind opțiunea de \*Grab\*, prin apăsarea butonului lateral de pe controller.  

Apoi aruncă mingea simulând gestul și eliberând butonul.  

Câinele Corgi aleargă după minge și o aduce aproape de punctul de start al utilizatorului.  

Jocul se poate repeta de mai multe ori în același mod.



---





\## Structura fișierelor



Fișierele mari (modele 3D, sunete, animații, texturi) nu sunt incluse în acest repository GitLab, din cauza limitării de spațiu și pentru a păstra un proiect curat și ușor de analizat.  

Accesează fișierele necesare rulării aplicației din Google Drive:  

🔗 \[Link către Google Drive – Assets și apk-urile versiunilor aplicației](https://drive.google.com/drive/folders/1qwTC4fGoUbzXw\_z5jMypyvkq\_D\_ekL3z)



\### Structura conținutului din Drive



\- `Assets\_V1/`, `Assets\_V2/`, ... – fiecare conține folderul `Assets/` complet pentru versiunea respectivă  

\- `apk\_builds/` – fișiere `.apk` gata de instalare pe \*\*Meta Quest 2\*\*



---



\## Cum folosești proiectul complet



1\. Clonează sau descarcă acest repository.

2\. Din Google Drive, descarcă folderul `Assets/` corespunzător versiunii tale.

3\. Copiază folderul `Assets/` din Drive \*\*peste cel existent în proiectul local\*\*  

&nbsp;  (va înlocui `scripturi/` și `scena/`, dar codul rămâne același).

4\. Deschide proiectul cu Unity (\*\*versiunea 2022.3.22f1 LTS\*\*) și urmează pașii din secțiunea \*Setup în Unity\*.

5\. Pentru testare pe dispozitiv, instalează `.apk` din Drive sau generează unul nou din Unity.

---



\## ❗ Notă importantă



\- Scena din `Assets/Scenes/` este inclusă \*\*doar pentru referință\*\* – nu va funcționa complet fără asseturile din Drive.

\- Script-urile C# se regăsesc integral în folderul `Assets/Scripts/`.

\- Asigură-te că \*\*înlocuiești complet\*\* folderul `Assets/` din GitLab local cu cel descărcat din Drive, altfel scenele nu vor fi funcționale.





\## Setup în Unity



\###  Tehnologii utilizate



\- \*\*Unity Hub\*\* cu \*\*Unity 2022.3.22f1 LTS\*\*

\- \*\*Android Build Support\*\* (cu SDK/NDK și OpenJDK)

\- \*\*Cască VR Meta Quest 2\*\*

\- \*\*Meta Quest Developer Hub (MQDH) 5.2.1\*\*  

&nbsp; ↳ \[Descarcă de aici](https://developer.oculus.com/downloads/package/meta-quest-developer-hub/)

\- \*\*Meta Horizon\*\* (versiunea aplicației testată: \*\*323.0.0.16.109\*\*)

\- \*\*Meta Quest Casting\*\* pentru vizualizarea sesiunilor VR

\- \*\*Visual Studio 2022\*\* (pentru scrierea codului C#)

\- \*\*C#\*\* (Unity Scripting API)



\### Pachete necesare:



Asigură-te că ai instalat în `Package Manager`:



\- \*\*XR Plugin Management\*\*

\- \*\*Oculus XR Plugin\*\*

\- \*\*OpenXR Plugin\*\*

\- \*\*XR Interaction Toolkit\*\*

\- \*\*XR Hands (opțional)\*\*

\- \*\*Input System\*\*

\- \*\*URP + Post-Processing\*\*



> \*Project-ul pornește din VR Core Template cu URP configurat.\*



\### Configurare Project Settings:



1\. `Edit > Project Settings > XR Plugin Management`:

&nbsp;  - Activează \*\*Oculus\*\* pentru Android

&nbsp;  - Activează \*\*OpenXR\*\* (dacă folosești Interaction Toolkit)



2\. `Player Settings > Other Settings`:

&nbsp;  - Setați:

&nbsp;    - `Color Space`: \*\*Linear\*\*

&nbsp;    - `Graphics API`: \*\*Vulkan\*\* sau \*\*OpenGLES3\*\*

&nbsp;    - `Minimum API Level`: \*\*Android 10.0 (API 29)\*\*



3\. `Build Settings`:

&nbsp;  - Platformă: \*\*Android\*\*

&nbsp;  - Setați scenele corecte în `Scenes in Build` 

&nbsp;  - Bifați `Development Build` doar pentru test



---



\## Interacțiuni implementate



\- \*\*Buton interactiv\*\* – pornește comportamente ale câinelui

\- \*\*NavMeshAgent\*\* – navigație automată a câinelui

\- \*\*Animator Controller\*\* – comportamente animate: mers, mâncat, alergat, stat, dă din coadă

\- \*\*Sistem scor + iconițe (stea, inimă) + confetti\*\*

\- \*\*Trigger-uri pentru minge și perie\*\*

\- \*\*Sunete realiste\*\* pentru lătrat blând, respirație, mâncat, alergat



---



\##  Build \& testare pe Meta Quest 2



\### 1. Activează Developer Mode pe cască:



\- Descarcă aplicația \*\*Meta Horizon\*\* pe telefon (Android/iOS)

\- Creează cont Meta și adaugă casca

\- Accesează:

&nbsp; ```

&nbsp; Devices > Developer Mode > ON

&nbsp; ```



\### 2. Conectează casca prin USB-C



\- Activează „Allow USB debugging” în cască

\- În Windows, acceptă toate permisiunile



\### 3. Build `.apk` din Unity



1\. În Unity:

&nbsp;  - `File > Build Settings > Android`

&nbsp;  - Selectează scena curentă

&nbsp;  - Click `Build` și salvează fișierul `.apk`



2\. Instalează pe cască folosind:

&nbsp;  - \*\*Meta Quest Developer Hub\*\* (MQDH)- adaugă build-ul apk in secțiunea cu aplicațiile tale 

&nbsp;  - Sau terminal ADB:

&nbsp;    ```bash

&nbsp;    adb install nume\_aplicatie.apk

&nbsp;    ```



\### 4. Rularea aplicației și setări suplimentare 



\- Pune casca pe cap

\- Utilizatorul iși setează pe cască opțiunile pentru limita mediului de joc și nivelul podelei.(boundary și floor level din setări) 

Limita mediului trebuie să fie una rezonabilă, pentru a permite mișcarea în scenă a utilizatorului

\- Activează opțiunea de Hand tracking pentru folosirea de VR hands în jocuri(implementată în versiunile V2 -> v4)

\- Accesează:

&nbsp; ```

&nbsp; Apps > Unknown Sources > \[Numele aplicației]

&nbsp; ```



---



\## Asset-uri folosite



| Tip         | Link |

|-------------|------|

| Podea        | \[Stylized Textures](https://assetstore.unity.com/packages/2d/textures-materials/25-free-stylized-textures-grass-ground-floors-walls-more-241895) |

| Câine        | \[Animated Dogs – Bublisher](https://assetstore.unity.com/packages/3d/characters/animals/mammals/3d-stylized-animated-dogs-kit-284699) |

| Case         | \[Medieval Buildings](https://assetstore.unity.com/packages/3d/environments/historic/lowpoly-medieval-buildings-58289) |

| Farm assets  | \[Lite Farm Pack](https://assetstore.unity.com/packages/3d/environments/industrial/lite-farm-pack-low-poly-3d-art-by-gridness-243315) |

| Masă \& scaun | \[Outdoor Furniture](https://assetstore.unity.com/packages/3d/props/furniture/summer-open-air-table-and-chair-94677) |

| Perie        | \[Stylized Brush](https://assetstore.unity.com/packages/3d/props/stylized-brush-hair-310778) |

| Minge        | \[Low Poly Ball](https://assetstore.unity.com/packages/3d/low-polygon-soccer-ball-84382) |

| Bol          | \[Steel Bowl – Sketchfab](https://www.fab.com/listings/5b1ed861-f24e-4d6c-bdd7-1cd646938339) |



---



\## Sunete utilizate



\- Mâncat: \[Freesound](https://freesound.org/people/qubodup/sounds/741034/)

\- Respirație: \[Freesound](https://freesound.org/people/jayylls/sounds/654649/)

\- Lătrat blând: \[Freesound](https://freesound.org/people/Alex\_hears\_things/sounds/758868/)

\- Alergat: \[Freesound](https://freesound.org/people/ilmari\_freesound/sounds/585911/)



---



\## Recompense vizuale



\- Stea: \[Flaticon](https://www.flaticon.com/free-icon/star\_7269732)

\- Inimă: \[PNGTree](https://pngtree.com/freepng/beautiful-bright-red-heart\_6252575.html)

\- Confetti fluture-pentru sprite (în descrierea videoclipului): \[YouTube](https://www.youtube.com/watch?v=NNBkTTykXU0)



---



\## Observații finale



\- Fiecare versiune este \*\*autonomă\*\* și poate fi testată individual.

\- Se recomandă parcurgerea în ordine (V1 → V4) pentru a respecta progresia terapeutică.

\- Aplicațiile necesită conexiune la internet și nu colectează date personale.

\- Ideal de testat într-un mediu liniștit, cu prezența unui adult (mamă/terapeut).



---

\## Notă etică



Acest proiect a fost realizat în cadrul lucrării de licență și este bazat pe un caz real de terapie VR aplicată unui copil diagnosticat cu tulburare din spectrul autist și dizabilitate intelectuală ușoară.  



Pentru protejarea confidențialității, acest repository \*\*nu conține date personale, imagini, filmări sau informații medicale identificabile\*\*.  



Codul sursă este publicat exclusiv în scopuri academice și educaționale. Rezultatele testărilor sunt prezentate într-o formă \*\*generalizată și anonimizată\*\*, fără a compromite identitatea participantului.  



Proiectul respectă principiile etice în lucrul cu populații vulnerabile și aspectele LSEP aferente.



\## Contact



Pentru întrebări, instalare sau feedback:  

\*\*Ana Maria Cernei\*\* 

Contact: anicernei@gmail.com

---



