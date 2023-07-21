using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static Shop;

public class QuizManager : MonoBehaviour
{
    public Question[] quizQuestions;
    public Button[] optionButtons;
    public int correctOption;
    public Text quizQuestion;

    public GameController gameController;

    private bool answered = false;

    public Image PanelColor;

    public Button[] jokerButtons;

    private bool x2Enabled = false;
    private int selectOptionTimes = 0; //used to check x2 joker

    private Color defaultButtonColor;
    private Color defaultPanelColor;



    public Color DefaultButtonColor { get => defaultButtonColor; set => defaultButtonColor = value; }


    public Jokers jokers;

    private QuizTimer quizTimer;

    private void Awake()
    {
        quizTimer = GetComponent<QuizTimer>();
        if (ColorUtility.TryParseHtmlString("#85FF31", out Color color))
        {
            defaultButtonColor = color;
        }
        else
        {
            defaultButtonColor = Color.white; // Varsayýlan bir renk deðeri atayabilirsiniz
            Debug.LogError("Geçersiz hexadecimal renk deðeri!");
        }
        if (ColorUtility.TryParseHtmlString("#B123DA", out Color color2))
        {
            defaultPanelColor = color2;
        }
        else
        {
            defaultPanelColor = Color.white; // Varsayýlan bir renk deðeri atayabilirsiniz
            Debug.LogError("Geçersiz hexadecimal renk deðeri!");
        }
    }
    private void Start()
    { 
        quizQuestions = new Question[]
        {
            new Question("Bu tabloya yol açması en olası bakteri aşağıdakilerden hangisidir?", new string[] { "Burkholderia cepacia kompleks ", "Stenotrophomonas maltophilia ", "Acinetobacter baumannii kompleks ", "Pseudomonas aeruginosa " }, 
            new string[] { "Daha önce antibiyotik tedavisi almıştır.", "Yaş 65 kadın hasta", "Yüksek Ateş Ve titreme", "Hastadan alınan kan kültüründen oksidaz negatif, DNaz pozitif, non-fermenter bir gram negatif basil izole ediliyor. İn vitro duyarlılık testinde etken bakterinin sefalosporinlere, karbapenemlere, aminoglikozitlere ve florokinolonlara dirençli, trimetoprim-sulfametoksazole yüksek tedavi dozunda duyarlı olduğu tespit ediliyor." }, 1),
            new Question("Bu hastada biyopsi örneğinden yapılan kültürde üremesi en olası etken aşağıdakilerden hangisidir? ", new string[] { "Candida albicans ", "Aspergillus flavus ", "Fonsecaea pedrosoi", "Fusarium solani " }, new string[] { "Tek bacakta çok yavaş ilerlemiş verrüköz ve karnabahar benzeri lezyonlar.", "•biyopsinin mikroskopik incelemesinde, koyu kahverengi renkli, tomurcuklanma göstermeyen, büyük, kalın duvarlı, enine ve boyuna septumlu, yuvarlak, muriform hücreler" }, 2),
            new Question("Bu sastaya tanı amaçlı açık akciğer biyopsisi yapılıyor. Biyopsi incelemesinde aşağıdakilerden hangisinin saptanması en az olasıdır? ",new string[] { "Parankim kaybı ", "Granülom oluşumu ", "Bal peteği fibrozisi", "Fibroblastik odaklar" },new string[] { "67 yaşında Erkek bir hasta ", "Nefes darlığı ve kuru öksürük ve merdiven çıkamama", "Siyanotik görünümde ve çomaklaşma olan parmaklar.", "Tomografisinde her iki akciğerde özellikle alt lob subplevral alanda retiküler opasite alanları ile traksiyon bronşiektazi" }, 1),
            new Question("Bu olgular ışığında için en olası histolojik tanı aşağıdakilerden hangisidir", new string[] { "Koryokarsinom ", "Mol hidatidiform ", "İnvaziv mol ", "Hidropik abortus" },new string[] { "Kadın 45 yaşında hasta", "Vajinal kanama şikayeti ile geldi", "ultrasonografisinde plasentada “kar fırtınası paterni” görülüyor, fetus saptanmıyor", "Miyometriyal invazyon görülmüyor" , "Küretaj materyalinin histolojik incelemesinde, ileri derecede genişlemiş ve hidropik özellikte koryonik villuslar ve bu villusların bir kısmını çepeçevre saran, hafif hücresel atipili trofoblastik hücre proliferasyonu tespit ediliyor"}, 1),
            new Question("Bu lezyon için en olası tanı aşağıdakilerden hangisidir? ", new string[] { "Adrenal korteks karsinomu ", " Nodüler kortikal hiperplazi ", "Aldosteron salgılayan adenom", "Feokromositoma" }, new string[] { "Üç yıldır hipertansiyon tedavisi görmekte", "bilgisayarlı tomografi incelemesinde sağ adrenal yerleşimli kitle saptanarak opere edilmiş", "47 yaşında kadın hasta", "adrenalektomi materyalinde; 1,5 cm çapında, iyi sınırlı, sarı renkli bir kitle tespit ediliyor." ,"Kitlenin mikroskopik incelemesinde; kitle içinde kordonlar ve trabeküller oluşturan, intrasitoplazmik yağ içeren ve berrak sitoplazmalı uniform kortikal hücreler izleniyor" ,"İntrasitoplazmik eozinofilik laminer cisimcikler dikkati çekiyor. Kitle dışı adrenal dokuda bir anormallik görülmüyor." },2),
            new Question("Bu hasta için en olası tanı aşağıdakilerden hangisidir? ", new string[] { "Pemfigus vulgaris ", "Büllöz pemfigoid", " Dermatitis herpetiformis ", " Epidermolizis bülloza" }, new string[] { "52 yaşında kadın hasta", "gövde ve ağız içine yerleşen içi su dolu kabarcıklar ve bunların patlamasıyla ortaya çıkan ağrılı yaralara sahip", "ermatolojik muayenede gövde ve ekstremitelere yerleşen büller ve erozyonlar ile damak ve bukkal mukozada erozyonlar tespit ediliyor.", "Deri biyopsisinde, epidermiste suprabazal akantolitik bül ve direkt immünofloresan incelemede tüm epidermisi kapsayacak şekilde interselüler IgG birikimi görülüyor" }, 0),
            new Question("Bu lezyonların mikroskopik incelemesinde aşağıdaki bulgulardan hangisinin saptanması en olasıdır? ", new string[] { "Miyelin kaybı", " Kapiller damar duvarlarında amiloid birikimi ", "Nörofibriler yumaklar ", "Nöropilde vakuoler dejenerasyon  " }, new string[] { "63 yaşonda kadın hasta", "40 yıldır süre gelen görme kaybı ve değişken paralizi ataklarına sahip", "Trafik kazasıyla eksitus olmuştur.", "Otopsisinde beyinde periventriküler beyaz cevherde ve medulla spinalis beyaz cevherinde bir kısmı sklerotik, bir kısmı gri renkte çok sayıda düzensiz şekilli plak saptanıyor" },0),
            new Question("Bu hastanın mevcut klinik durumunu açıklayan en olası patolojik süreç aşağıdakilerden hangisidir? ", new string[] { "Niasin toksisitesi ", "A vitamini toksisitesi", " Piridoksin toksisitesi ", "D vitamini toksisitesi " }, new string[] { "25 yaşında erkek", "ani başlangıçlı şiddetli baş ağrısı, baş dönmesi, bulantı, kusma ve bulanık görme", "anamnezinden akut promiyelositik lösemi tedavisi altında olduğu öğreniliyor."},1),
            new Question("Bu hasta için en olası tanı aşağıdakilerden hangisidir? ", new string[] { "Nodüler sklerozan ", "Hodgkin lenfoma ", "Lenfoblastik lenfoma", "Timoma Granülositik sarkom" }, new string[] { "18 yaşında kadın hasta", "solunum sıkıntısı, öksürük ve gece terlemesi şikâyetleri", "Radyolojik incelemede mediasteni genişleten bir kitle tespit ediliyor", "Kitleden alınan kor biyopsinin incelemesinde matür lenfositler, histiyositler, eozinofiller ve plazma hücrelerinden oluşan polimorfik zemin içinde multinükleer veya multilobüler nükleuslu atipik hücreler izleniyor." ,"İmmünhistokimyasal çalışmalarda atipik hücrelerin CD3 ve CD20 ile negatif; Pax5, CD15 ve CD30 ile pozitif boyanma gösterdiği saptanıyor." },0),
            new Question("Bu olgunun klinikopatolojik ayırıcı tanısında ön planda düşünülmesi gereken hastalık aşağıdakilerden hangisidir? ", new string[] { "Wilson hastalığı ", "Caroli hastalığı ", "Kistik fibrozis ", "Konjenital hepatik fibrozis" }, new string[] { "14 yaşında erkek", "Portal hipertansiyona ikincil semptomlara sahip", "karaciğer biyopsisinde, parankimi düzensiz bir şekilde bölen kalın kollajenöz septalarla genişlemiş portal alanlar ve kenarında safra yollarıyla devamlılık gösteren anormal şekilli safra kanalları izleniyor"},3)
        };
    }

    void OnEnable()
    {
        QuizTimer.OnQuizFinished += OnQuizFinishedHandler;
    }

    void OnDisable()
    {
        QuizTimer.OnQuizFinished -= OnQuizFinishedHandler;
    }

    // Olay tetiklendiğinde yapılacak işlemler
    void OnQuizFinishedHandler()
    {
        // Quiz bittiğinde yapılacak işlemleri burada gerçekleştirin
        StartCoroutine(TimeOutAnswer(2));
        // Örneğin: Sonuçları gösterebilir veya yeni bir quiz başlatabilirsiniz.
    }
    public void prepareQuiz(int quizQuestionID)
    {
        quizTimer.StartTimer();
        selectOptionTimes = 0;
        x2Enabled = false;
        PanelColor.color = defaultPanelColor;
        for (int i  = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponent<Image>().color = DefaultButtonColor;
            optionButtons[i].interactable = true;
        }

        answered = false;
        UpdateQuizQuestion(quizQuestionID);
        UpdateOptionButtons(quizQuestionID);
        correctOption  = quizQuestions[quizQuestionID].correctAnswer;
        SetJokerButtons();
    }
    public void UpdateQuizQuestion(int quizQuestionID)
    {
        quizQuestion.text = quizQuestions[quizQuestionID].questionText;
    }
    public void UpdateOptionButtons(int quizQuestionID)
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int optionIndex = i;
            optionButtons[i].GetComponentInChildren<Text>().text = quizQuestions[quizQuestionID].options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(delegate { ButtonClicked(optionIndex); });
        }
    }

    public void SetJokerButtons()
    {
        for (int i = 0; i < jokers.purchasedJokers.Count; i++)
        {
            int currentIndex = i;
            int jokerID = jokers.purchasedJokers[currentIndex].shopItemId; // @MGurcan TODO: NEED REFACTOR jokerID and purchasedJokerIndex so tricky-rough coded
            jokerButtons[jokerID].onClick.RemoveAllListeners();

            jokerButtons[jokerID].GetComponentInChildren<Text>().text = jokers.purchasedJokers[currentIndex].purchaseCount + "";
            if (jokerID == 0)
            {
                jokerButtons[jokerID].onClick.AddListener(() => Activate_50_Joker(currentIndex));
            }
            else if (jokerID == 1)
            {
                jokerButtons[jokerID].onClick.AddListener(() => Activate_x2_Joker(currentIndex));
            }
            else if (jokerID == 2)
            {
                jokerButtons[jokerID].onClick.AddListener(() => Activate_ExtraTime_Joker(currentIndex));
            }
        }  
    }

    private void ButtonClicked(int selectedOptionIndex)
    {
        if (answered) return;
        if (!x2Enabled)
        {
            answered = true;
        }
        else
        {
            if(selectOptionTimes == 2)
                answered = true;
        }
        

        if (selectedOptionIndex == correctOption)
        {
            StartCoroutine(CorrectAnswer(2, selectedOptionIndex));
        }
        else
        {      
            StartCoroutine(WrongAnswer(2, selectedOptionIndex));
        }

    }

    public void Activate_50_Joker(int purchaseJokerIndex)
    {
        if(jokers.purchasedJokers[purchaseJokerIndex].purchaseCount > 0) { 
        
            jokers.purchasedJokers[purchaseJokerIndex].purchaseCount--;

            int jokerID = jokers.purchasedJokers[purchaseJokerIndex].shopItemId;
            jokerButtons[jokerID].GetComponentInChildren<Text>().text = jokers.purchasedJokers[purchaseJokerIndex].purchaseCount + "";

            Debug.Log("Activate 50 Joker Implemented");
            int deleteCount = 0;
            for (int i = 0; i < optionButtons.Length; i++)
            {
                if (i != correctOption && deleteCount < 2)
                {
                    optionButtons[i].interactable = false;
                    deleteCount++;
                }
            }
        }

    }
    public void Activate_ExtraTime_Joker(int purchaseJokerIndex)
    {
        if (jokers.purchasedJokers[purchaseJokerIndex].purchaseCount > 0)
        {
            jokers.purchasedJokers[purchaseJokerIndex].purchaseCount--;

            int jokerID = jokers.purchasedJokers[purchaseJokerIndex].shopItemId;
            jokerButtons[jokerID].GetComponentInChildren<Text>().text = jokers.purchasedJokers[purchaseJokerIndex].purchaseCount + "";
            
            Debug.Log("Activate ExtraTime Joker Implemented");
            quizTimer.AddExtraTime(10);
        }

    }
    public void Activate_x2_Joker(int purchaseJokerIndex)
    {
        if (jokers.purchasedJokers[purchaseJokerIndex].purchaseCount > 0)
        {
            jokers.purchasedJokers[purchaseJokerIndex].purchaseCount--;

            int jokerID = jokers.purchasedJokers[purchaseJokerIndex].shopItemId;
            jokerButtons[jokerID].GetComponentInChildren<Text>().text = jokers.purchasedJokers[purchaseJokerIndex].purchaseCount + "";

            Debug.Log("Activate x2 Joker Implemented");
            x2Enabled = true;
        }

    }

    private IEnumerator CorrectAnswer(float delay, int selectedOptionIndex)
    {
        PanelColor.color = Color.green;
        optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.yellow;
        quizTimer.StopTimer();
        yield return new WaitForSeconds(delay);
        gameController.CloseQuiz(true);
    }
    private IEnumerator WrongAnswer(float delay, int selectedOptionIndex)
    {
        if (!x2Enabled)
        {
            optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
            PanelColor.color = Color.red;
            quizTimer.StopTimer();
            yield return new WaitForSeconds(delay);
            gameController.CloseQuiz(false);
        }
        else
        {
            selectOptionTimes++;
            if(selectOptionTimes == 2)
            {
                optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
                PanelColor.color = Color.red;
                yield return new WaitForSeconds(delay);
                gameController.CloseQuiz(false);
            }
            else
            {
                optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
                optionButtons[selectedOptionIndex].interactable = false;
            }
        }

    }
    private IEnumerator TimeOutAnswer(float delay)
    {
        
        if(PanelColor != null)
        {
            PanelColor.color = Color.red;
            quizTimer.StopTimer();
            yield return new WaitForSeconds(delay);

            gameController.CloseQuiz(false);
        }
            
            
        


    }
}
