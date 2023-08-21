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
                "Solunum Sýkýntýsý" },
            new List<string> { "clue kazanamadý 1", "tekrar dene 1" },
            1),
            
            new Question("Bu hasta için en olasý taný aþaðýdakilerden hangisidir?",
            new string[] { "Pemfigus vulgaris ", "Bulloz pemfigoid", " Dermatitis herpetiformis ", " Epidermolizis bulloza" },
            new List<string> {
                "52 Yasinda Kadin Hasta",
                "Agrili Yaralanma Var",
                "Epidermiste interselüler IgK",
                "Bukkal Mukozada Erozyon Tespiti" },
            new List<string> { "clue kazanamadý 1", "tekrar dene 1" },
            0),
            
            new Question("Bu hastanýn mevcut klinik durumunu açýklayan en olasý patolojik süreç aþaðýdakilerden hangisidir? ",
            new string[] { "Niasin toksisitesi ", "A vitamini toksisitesi", " Piridoksin toksisitesi ", "D vitamini toksisitesi " },
            new List<string> {
                "25 Yasinda Erkek",
                "Ani Siddetli Bas Agrisi",
                "Bas Donmesi",
                "Bulanti ve Kusma" },
            new List<string> { "clue kazanamadý 1", "tekrar dene 1" },
            1),
            
            new Question("Bu hasta için en olasý taný aþaðýdakilerden hangisidir?",
            new string[] { "Noduler sklerozan ", "Hodgkin lenfoma ", "Lenfoblastik lenfoma", "Timoma Granulositik sarkom" },
            new List<string> {
                "18 yasinda kadin hasta",
                "Solunum Sikintisi, Oksuruk",
                "Gece Terlemesi",
                "Mediasteni genisleten bir kitle tespiti" },
            new List<string> { "clue kazanamadý 1", "tekrar dene 1" },
            0),

            new Question("Bu olgunun klinikopatolojik ayýrýcý tanýsýnda ön planda düþünülmesi gereken hastalýk aþaðýdakilerden hangisidir?",
            new string[] { "Wilson hastaligi ", "Caroli hastaligi ", "Kistik fibrozis ", "Konjenital hepatik fibrozis" },
            new List<string> {
                "14 yasinda erkek",
                "Portal hipertansiyona ikincil semptomlara sahip",
                "Safra yolunda anormal sekilli safra kanali",
                "Karaciger biyopsisinde parankimi duzensiz" },
            new List<string> { "clue kazanamadý 1", "tekrar dene 1" },
            1),

            new Question("Bu tabloya yol açmasý en olasý bakteri aþaðýdakilerden hangisidir?",
            new string[] { "Burkholderia cepacia kompleks ", "Stenotrophomonas maltophilia ", "Acinetobacter baumannii kompleks ", "Pseudomonas aeruginosa " },
            new List<string> {
                "Daha önce antibiyotik tedavisi almýþtýr.",
                "Yaþ 65 kadýn hasta",
                "Yüksek Ateþ Ve titreme",
                "Hastadan alýnan kan kültüründen oksidaz negatif, DNaz pozitif, non-fermenter bir gram negatif basil izole ediliyor. Ýn vitro duyarlýlýk testinde etken bakterinin sefalosporinlere, karbapenemlere, aminoglikozitlere ve florokinolonlara dirençli, trimetoprim-sulfametoksazole yüksek tedavi dozunda duyarlý olduðu tespit ediliyor." },
            new List<string> {"clue kazanamadý 1", "tekrar dene 1" },
            1),

            new Question("Bu hastada biyopsi örneðinden yapýlan kültürde üremesi en olasý etken aþaðýdakilerden hangisidir? ",
            new string[] { "Candida albicans ", "Aspergillus flavus ", "Fonsecaea pedrosoi", "Fusarium solani " },
            new List<string> {
                "Tek bacakta çok yavaþ ilerlemiþ verrüköz ve karnabahar benzeri lezyonlar.",
                "•biyopsinin mikroskopik incelemesinde, koyu kahverengi renkli, tomurcuklanma göstermeyen, büyük, kalýn duvarlý, enine ve boyuna septumlu, yuvarlak, muriform hücreler" },
            new List<string> {"clue kazanamadý 2", "tekrar dene 2" },
            2),

            new Question("Bu sastaya taný amaçlý açýk akciðer biyopsisi yapýlýyor. Biyopsi incelemesinde aþaðýdakilerden hangisinin saptanmasý en az olasýdýr? ",
            new string[] { "Parankim kaybý ", "Granülom oluþumu ", "Bal peteði fibrozisi", "Fibroblastik odaklar" },
            new List<string> {
                "67 yaþýnda Erkek bir hasta ",
                "Nefes darlýðý ve kuru öksürük ve merdiven çýkamama",
                "Siyanotik görünümde ve çomaklaþma olan parmaklar.",
                "Tomografisinde her iki akciðerde özellikle alt lob subplevral alanda retiküler opasite alanlarý ile traksiyon bronþiektazi" },
            new List<string> {"clue kazanamadý 3", "tekrar dene 3" },
            1),

            new Question("Bu olgular ýþýðýnda için en olasý histolojik taný aþaðýdakilerden hangisidir",
            new string[] { "Koryokarsinom ", "Mol hidatidiform ", "Ýnvaziv mol ", "Hidropik abortus" },
            new List<string> {
                "Kadýn 45 yaþýnda hasta",
                "Vajinal kanama þikayeti ile geldi",
                "ultrasonografisinde plasentada “kar fýrtýnasý paterni” görülüyor, fetus saptanmýyor",
                "Miyometriyal invazyon görülmüyor" ,
                "Küretaj materyalinin histolojik incelemesinde, ileri derecede geniþlemiþ ve hidropik özellikte koryonik villuslar ve bu villuslarýn bir kýsmýný çepeçevre saran, hafif hücresel atipili trofoblastik hücre proliferasyonu tespit ediliyor"},
            new List<string> {"clue kazanamadý 4", "tekrar dene 4" },
            1),

            new Question("Bu lezyon için en olasý taný aþaðýdakilerden hangisidir? ",
            new string[] { "Adrenal korteks karsinomu ", " Nodüler kortikal hiperplazi ", "Aldosteron salgýlayan adenom", "Feokromositoma" },
            new List<string> {
                "Üç yýldýr hipertansiyon tedavisi görmekte",
                "bilgisayarlý tomografi incelemesinde sað adrenal yerleþimli kitle saptanarak opere edilmiþ",
                "47 yaþýnda kadýn hasta", "adrenalektomi materyalinde; 1,5 cm çapýnda, iyi sýnýrlý, sarý renkli bir kitle tespit ediliyor." ,
                "Kitlenin mikroskopik incelemesinde; kitle içinde kordonlar ve trabeküller oluþturan, intrasitoplazmik yað içeren ve berrak sitoplazmalý uniform kortikal hücreler izleniyor" ,
                "Ýntrasitoplazmik eozinofilik laminer cisimcikler dikkati çekiyor. Kitle dýþý adrenal dokuda bir anormallik görülmüyor." },
            new List<string> {"clue kazanamadý 5", "tekrar dene 5" },
            2),

            new Question("Bu hasta için en olasý taný aþaðýdakilerden hangisidir? ",
            new string[] { "Pemfigus vulgaris ", "Büllöz pemfigoid", " Dermatitis herpetiformis ", " Epidermolizis bülloza" },
            new List<string> { "52 yaþýnda kadýn hasta", "gövde ve aðýz içine yerleþen içi su dolu kabarcýklar ve bunlarýn patlamasýyla ortaya çýkan aðrýlý yaralara sahip", "ermatolojik muayenede gövde ve ekstremitelere yerleþen büller ve erozyonlar ile damak ve bukkal mukozada erozyonlar tespit ediliyor.", "Deri biyopsisinde, epidermiste suprabazal akantolitik bül ve direkt immünofloresan incelemede tüm epidermisi kapsayacak þekilde interselüler IgG birikimi görülüyor" },
            new List<string> {"clue kazanamadý 6", "tekrar dene 6" },
            0),

            new Question("Bu lezyonlarýn mikroskopik incelemesinde aþaðýdaki bulgulardan hangisinin saptanmasý en olasýdýr? ",
            new string[] { "Miyelin kaybý", " Kapiller damar duvarlarýnda amiloid birikimi ", "Nörofibriler yumaklar ", "Nöropilde vakuoler dejenerasyon  " },
            new List<string> { "63 yaþonda kadýn hasta", "40 yýldýr süre gelen görme kaybý ve deðiþken paralizi ataklarýna sahip", "Trafik kazasýyla eksitus olmuþtur.", "Otopsisinde beyinde periventriküler beyaz cevherde ve medulla spinalis beyaz cevherinde bir kýsmý sklerotik, bir kýsmý gri renkte çok sayýda düzensiz þekilli plak saptanýyor" },
            new List<string> {"clue kazanamadý 7", "tekrar dene 7" },
            0),

            new Question("Bu hastanýn mevcut klinik durumunu açýklayan en olasý patolojik süreç aþaðýdakilerden hangisidir? ",
            new string[] { "Niasin toksisitesi ", "A vitamini toksisitesi", " Piridoksin toksisitesi ", "D vitamini toksisitesi " },
            new List<string> { "25 yaþýnda erkek", "ani baþlangýçlý þiddetli baþ aðrýsý, baþ dönmesi, bulantý, kusma ve bulanýk görme", "anamnezinden akut promiyelositik lösemi tedavisi altýnda olduðu öðreniliyor."},
            new List<string> {"clue kazanamadý 8", "tekrar dene 8" },
            1),

            new Question("Bu hasta için en olasý taný aþaðýdakilerden hangisidir? ",
            new string[] { "Nodüler sklerozan ", "Hodgkin lenfoma ", "Lenfoblastik lenfoma", "Timoma Granülositik sarkom" },
            new List<string> { "18 yaþýnda kadýn hasta", "solunum sýkýntýsý, öksürük ve gece terlemesi þikâyetleri", "Radyolojik incelemede mediasteni geniþleten bir kitle tespit ediliyor", "Kitleden alýnan kor biyopsinin incelemesinde matür lenfositler, histiyositler, eozinofiller ve plazma hücrelerinden oluþan polimorfik zemin içinde multinükleer veya multilobüler nükleuslu atipik hücreler izleniyor." ,"Ýmmünhistokimyasal çalýþmalarda atipik hücrelerin CD3 ve CD20 ile negatif; Pax5, CD15 ve CD30 ile pozitif boyanma gösterdiði saptanýyor." },
            new List<string> {"clue kazanamadý 9", "tekrar dene 9" },
            0),
        };
    public Question[] GetQuestions()
    {
        return quizQuestions;
    }
}
