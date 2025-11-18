# Unity week 2: Formal elements

A project with step-by-step scenes illustrating some of the formal elements of game development in Unity, including: 

משחק חללית - מטלה דגמים וטריגרים
משחק יריות 2D ב-Unity במסגרת קורס פיתוח משחקים באוניברסיטת אריאל.

🎮 קישורים

שחק עכשיו: https://davidstern135.itch.io/assignment-3-space-ship



תכונות שהוספתי
תכונות מהמטלה:
תכונה 2: תצוגת ניקוד קבועה
הניקוד מוצג בפינה השמאלית העליונה של המסך ולא זז עם החללית.

משתמש ב-Canvas ו-TextMeshPro

תכונה 5: הגבלה של מהירות וכמות הלייזרים שהחללית יכולה לירות.
השחקן חייב לחכות בין יריות ויש לו מספר מוגבל של קרני לייזר(ניתן לשינוי בinspector)

זמן המתנה: חצי שנייה בין יריות
כדורים בהתחלה: 30
מונה כדורים מוצג על המסך
הכדורים מתאפסים כשעוברים לשלב הבא.


תכונות מקוריות:

    תכונה ראשונה: 
תוספת ירי מהיר של ללא הגבלה של מס היריות אבל לזמן מוגבל.
פריט שאפשר לאסוף שנותן יכולת לירות מהר יותר.
בנוסף הוספתי שניתן ללחוץ "רווח" בצורה רציפה והחללית תירה על "אוטומט"


נמשך 5 שניות ומקטין את זמן ההמתנה בין יריות ל0.1 שניות.
יש אינדיקטור שמראה שהתוספת פעילה וכמות הזמן שנותר לתוספת.

    תכונה שניה:
כדורים שנופלים מאויבים:
כאשר האויבים מושמדים יש סבירות שיפילו מחסנית עם "כדורים"/לייזרים.

סיכוי לנפילה: 20% מכל אויב
כל פריט נותן חמישה לייזרים
נעלם אחרי 3 שניות אם לא אוספים אותו.

    שליטה:
תנועה- נשלט על ידי החיצים
ירי- מקש ה"רווח"

    גרסה:    
6000.2.8f1

    איך להריץ:

פתח את הפרויקט ב-Unity
פתח את הסצנה Level1
לחץ Play



