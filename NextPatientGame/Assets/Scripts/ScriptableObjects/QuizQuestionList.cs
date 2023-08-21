using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestionList : MonoBehaviour
{
    private Question[] quizQuestions = new Question[]
        {
            new Question("Bu tabloya yol acmasi en olasi bakteri asagidakilerden hangisidir?",
            new string[] { "Burkholderia cepacia kompleks", "Stenotrophomonas maltophilia", "Acinetobacter baumannii kompleks", "Pseudomonas aeruginosa" },
            new List<string> {
                "Daha once antibiyotik kullandi",
                "Yas 65 kadin hasta",
                "Yuksek Ates Ve titreme",
                "Solunum S�k�nt�s�" },
            new List<string> { "clue kazanamad� 1", "tekrar dene 1" },
            1),
            
            new Question("Bu hasta i�in en olas� tan� a�a��dakilerden hangisidir?",
            new string[] { "Pemfigus vulgaris ", "Bulloz pemfigoid", " Dermatitis herpetiformis ", " Epidermolizis bulloza" },
            new List<string> {
                "52 Yasinda Kadin Hasta",
                "Agrili Yaralanma Var",
                "Epidermiste intersel�ler IgK",
                "Bukkal Mukozada Erozyon Tespiti" },
            new List<string> { "clue kazanamad� 1", "tekrar dene 1" },
            0),
            
            new Question("Bu hastan�n mevcut klinik durumunu a��klayan en olas� patolojik s�re� a�a��dakilerden hangisidir? ",
            new string[] { "Niasin toksisitesi ", "A vitamini toksisitesi", " Piridoksin toksisitesi ", "D vitamini toksisitesi " },
            new List<string> {
                "25 Yasinda Erkek",
                "Ani Siddetli Bas Agrisi",
                "Bas Donmesi",
                "Bulanti ve Kusma" },
            new List<string> { "clue kazanamad� 1", "tekrar dene 1" },
            1),
            
            new Question("Bu hasta i�in en olas� tan� a�a��dakilerden hangisidir?",
            new string[] { "Noduler sklerozan ", "Hodgkin lenfoma ", "Lenfoblastik lenfoma", "Timoma Granulositik sarkom" },
            new List<string> {
                "18 yasinda kadin hasta",
                "Solunum Sikintisi, Oksuruk",
                "Gece Terlemesi",
                "Mediasteni genisleten bir kitle tespiti" },
            new List<string> { "clue kazanamad� 1", "tekrar dene 1" },
            0),

            new Question("Bu olgunun klinikopatolojik ay�r�c� tan�s�nda �n planda d���n�lmesi gereken hastal�k a�a��dakilerden hangisidir?",
            new string[] { "Wilson hastaligi ", "Caroli hastaligi ", "Kistik fibrozis ", "Konjenital hepatik fibrozis" },
            new List<string> {
                "14 yasinda erkek",
                "Portal hipertansiyona ikincil semptomlara sahip",
                "Safra yolunda anormal sekilli safra kanali",
                "Karaciger biyopsisinde parankimi duzensiz" },
            new List<string> { "clue kazanamad� 1", "tekrar dene 1" },
            1),

            new Question("Bu tabloya yol a�mas� en olas� bakteri a�a��dakilerden hangisidir?",
            new string[] { "Burkholderia cepacia kompleks ", "Stenotrophomonas maltophilia ", "Acinetobacter baumannii kompleks ", "Pseudomonas aeruginosa " },
            new List<string> {
                "Daha �nce antibiyotik tedavisi alm��t�r.",
                "Ya� 65 kad�n hasta",
                "Y�ksek Ate� Ve titreme",
                "Hastadan al�nan kan k�lt�r�nden oksidaz negatif, DNaz pozitif, non-fermenter bir gram negatif basil izole ediliyor. �n vitro duyarl�l�k testinde etken bakterinin sefalosporinlere, karbapenemlere, aminoglikozitlere ve florokinolonlara diren�li, trimetoprim-sulfametoksazole y�ksek tedavi dozunda duyarl� oldu�u tespit ediliyor." },
            new List<string> {"clue kazanamad� 1", "tekrar dene 1" },
            1),

            new Question("Bu hastada biyopsi �rne�inden yap�lan k�lt�rde �remesi en olas� etken a�a��dakilerden hangisidir? ",
            new string[] { "Candida albicans ", "Aspergillus flavus ", "Fonsecaea pedrosoi", "Fusarium solani " },
            new List<string> {
                "Tek bacakta �ok yava� ilerlemi� verr�k�z ve karnabahar benzeri lezyonlar.",
                "�biyopsinin mikroskopik incelemesinde, koyu kahverengi renkli, tomurcuklanma g�stermeyen, b�y�k, kal�n duvarl�, enine ve boyuna septumlu, yuvarlak, muriform h�creler" },
            new List<string> {"clue kazanamad� 2", "tekrar dene 2" },
            2),

            new Question("Bu sastaya tan� ama�l� a��k akci�er biyopsisi yap�l�yor. Biyopsi incelemesinde a�a��dakilerden hangisinin saptanmas� en az olas�d�r? ",
            new string[] { "Parankim kayb� ", "Gran�lom olu�umu ", "Bal pete�i fibrozisi", "Fibroblastik odaklar" },
            new List<string> {
                "67 ya��nda Erkek bir hasta ",
                "Nefes darl��� ve kuru �ks�r�k ve merdiven ��kamama",
                "Siyanotik g�r�n�mde ve �omakla�ma olan parmaklar.",
                "Tomografisinde her iki akci�erde �zellikle alt lob subplevral alanda retik�ler opasite alanlar� ile traksiyon bron�iektazi" },
            new List<string> {"clue kazanamad� 3", "tekrar dene 3" },
            1),

            new Question("Bu olgular �����nda i�in en olas� histolojik tan� a�a��dakilerden hangisidir",
            new string[] { "Koryokarsinom ", "Mol hidatidiform ", "�nvaziv mol ", "Hidropik abortus" },
            new List<string> {
                "Kad�n 45 ya��nda hasta",
                "Vajinal kanama �ikayeti ile geldi",
                "ultrasonografisinde plasentada �kar f�rt�nas� paterni� g�r�l�yor, fetus saptanm�yor",
                "Miyometriyal invazyon g�r�lm�yor" ,
                "K�retaj materyalinin histolojik incelemesinde, ileri derecede geni�lemi� ve hidropik �zellikte koryonik villuslar ve bu villuslar�n bir k�sm�n� �epe�evre saran, hafif h�cresel atipili trofoblastik h�cre proliferasyonu tespit ediliyor"},
            new List<string> {"clue kazanamad� 4", "tekrar dene 4" },
            1),

            new Question("Bu lezyon i�in en olas� tan� a�a��dakilerden hangisidir? ",
            new string[] { "Adrenal korteks karsinomu ", " Nod�ler kortikal hiperplazi ", "Aldosteron salg�layan adenom", "Feokromositoma" },
            new List<string> {
                "�� y�ld�r hipertansiyon tedavisi g�rmekte",
                "bilgisayarl� tomografi incelemesinde sa� adrenal yerle�imli kitle saptanarak opere edilmi�",
                "47 ya��nda kad�n hasta", "adrenalektomi materyalinde; 1,5 cm �ap�nda, iyi s�n�rl�, sar� renkli bir kitle tespit ediliyor." ,
                "Kitlenin mikroskopik incelemesinde; kitle i�inde kordonlar ve trabek�ller olu�turan, intrasitoplazmik ya� i�eren ve berrak sitoplazmal� uniform kortikal h�creler izleniyor" ,
                "�ntrasitoplazmik eozinofilik laminer cisimcikler dikkati �ekiyor. Kitle d��� adrenal dokuda bir anormallik g�r�lm�yor." },
            new List<string> {"clue kazanamad� 5", "tekrar dene 5" },
            2),

            new Question("Bu hasta i�in en olas� tan� a�a��dakilerden hangisidir? ",
            new string[] { "Pemfigus vulgaris ", "B�ll�z pemfigoid", " Dermatitis herpetiformis ", " Epidermolizis b�lloza" },
            new List<string> { "52 ya��nda kad�n hasta", "g�vde ve a��z i�ine yerle�en i�i su dolu kabarc�klar ve bunlar�n patlamas�yla ortaya ��kan a�r�l� yaralara sahip", "ermatolojik muayenede g�vde ve ekstremitelere yerle�en b�ller ve erozyonlar ile damak ve bukkal mukozada erozyonlar tespit ediliyor.", "Deri biyopsisinde, epidermiste suprabazal akantolitik b�l ve direkt imm�nofloresan incelemede t�m epidermisi kapsayacak �ekilde intersel�ler IgG birikimi g�r�l�yor" },
            new List<string> {"clue kazanamad� 6", "tekrar dene 6" },
            0),

            new Question("Bu lezyonlar�n mikroskopik incelemesinde a�a��daki bulgulardan hangisinin saptanmas� en olas�d�r? ",
            new string[] { "Miyelin kayb�", " Kapiller damar duvarlar�nda amiloid birikimi ", "N�rofibriler yumaklar ", "N�ropilde vakuoler dejenerasyon  " },
            new List<string> { "63 ya�onda kad�n hasta", "40 y�ld�r s�re gelen g�rme kayb� ve de�i�ken paralizi ataklar�na sahip", "Trafik kazas�yla eksitus olmu�tur.", "Otopsisinde beyinde periventrik�ler beyaz cevherde ve medulla spinalis beyaz cevherinde bir k�sm� sklerotik, bir k�sm� gri renkte �ok say�da d�zensiz �ekilli plak saptan�yor" },
            new List<string> {"clue kazanamad� 7", "tekrar dene 7" },
            0),

            new Question("Bu hastan�n mevcut klinik durumunu a��klayan en olas� patolojik s�re� a�a��dakilerden hangisidir? ",
            new string[] { "Niasin toksisitesi ", "A vitamini toksisitesi", " Piridoksin toksisitesi ", "D vitamini toksisitesi " },
            new List<string> { "25 ya��nda erkek", "ani ba�lang��l� �iddetli ba� a�r�s�, ba� d�nmesi, bulant�, kusma ve bulan�k g�rme", "anamnezinden akut promiyelositik l�semi tedavisi alt�nda oldu�u ��reniliyor."},
            new List<string> {"clue kazanamad� 8", "tekrar dene 8" },
            1),

            new Question("Bu hasta i�in en olas� tan� a�a��dakilerden hangisidir? ",
            new string[] { "Nod�ler sklerozan ", "Hodgkin lenfoma ", "Lenfoblastik lenfoma", "Timoma Gran�lositik sarkom" },
            new List<string> { "18 ya��nda kad�n hasta", "solunum s�k�nt�s�, �ks�r�k ve gece terlemesi �ik�yetleri", "Radyolojik incelemede mediasteni geni�leten bir kitle tespit ediliyor", "Kitleden al�nan kor biyopsinin incelemesinde mat�r lenfositler, histiyositler, eozinofiller ve plazma h�crelerinden olu�an polimorfik zemin i�inde multin�kleer veya multilob�ler n�kleuslu atipik h�creler izleniyor." ,"�mm�nhistokimyasal �al��malarda atipik h�crelerin CD3 ve CD20 ile negatif; Pax5, CD15 ve CD30 ile pozitif boyanma g�sterdi�i saptan�yor." },
            new List<string> {"clue kazanamad� 9", "tekrar dene 9" },
            0),
        };
    public Question[] GetQuestions()
    {
        return quizQuestions;
    }
}
