---


---

<p>בס"ד<br>
<strong>לידך – ארגון סיוע ליולדת</strong><br>
<strong>תיאור הפרויקט</strong><br>
מערכת תיווך התנדבויות המציע סיוע לנשים אחרי לידה. באמצעות המערכת ניתן להגיש בקשת סיוע או הצעת עזרה, ולתווך בין המתנדבות למשפחות הנזקקות בשכונה.<br>
<strong>ישויות</strong><br>
•	יולדת<br>
•	מתנדבת<br>
•	בקשת סיוע<br>
•	הצעת עזרה<br>
•	התנדבות</p>
<p><strong>מיפוי שדות ליולדת</strong><br>
•	מזהה יולדת<br>
•	שם פרטי<br>
•	שם משפחה<br>
•	כתובת<br>
•	טלפון<br>
•	כתובת אימייל<br>
•	סטטוס (שבוע/חודש/זמן רב אחרי לידה)<br>
•	תאריך הצטרפות לארגון<br>
•	תאריך לידה<br>
•	כמות ילדים במשפחה<br>
•	כמות ילדים מתחת גיל 7<br>
•	סוג סיוע נדרש (כביסה/שמרטפות/ארוחות/ניקיון/אחר)<br>
•	רשימת בקשות מיוחדות<br>
•	הוראת קבע לארגון (יש/אין)</p>
<p><strong>מיפוי Routes ליולדת</strong><br>
•	שליפת רשימת היולדות<br>
GET <a href="http://leyadech.co.il/mothers">http://leyadech.co.il/mothers</a><br>
•	שליפת יולדת לפי מזהה<br>
GET <a href="http://leyadech.co.il/mothers/1">http://leyadech.co.il/mothers/1</a><br>
•	הוספת יולדת<br>
POST <a href="http://leyadech.co.il/mothers">http://leyadech.co.il/mothers</a><br>
•	עדכון שדות ליולדת<br>
PUT <a href="http://leyadech.co.il/mothers/1">http://leyadech.co.il/mothers/1</a><br>
•	עדכון סטטוס ליולדת<br>
PUT <a href="http://leyadech.co.il/mothers/1/status">http://leyadech.co.il/mothers/1/status</a><br>
•	מחיקת יולדת<br>
DELETE <a href="http://leyadech.co.il/mothers/1">http://leyadech.co.il/mothers/1</a><br>
•	עדכון בקשה מיוחדת ליולדת<br>
PUT <a href="http://leyadech.co.il/mothers/1/specialRequest">http://leyadech.co.il/mothers/1/specialRequest</a></p>
<p><strong>מיפוי שדות למתנדבת</strong><br>
•	מזהה מתנדבת<br>
•	שם פרטי<br>
•	שם משפחה<br>
•	כתובת<br>
•	טלפון<br>
•	כתובת אימייל<br>
•	סטטוס (קבועה/זמנית/לא פעילה)<br>
•	סוג סיוע<br>
•	תאריך הצטרפות</p>
<p><strong>מיפוי Routes למתנדבת</strong><br>
•	שליפת רשימת המתנדבות<br>
GET <a href="http://leyadech.co.il/volunteers">http://leyadech.co.il/volunteers</a><br>
•	שליפת מתנדבת לפי מזהה<br>
GET <a href="http://leyadech.co.il/volunteers/1">http://leyadech.co.il/volunteers/1</a><br>
•	הוספת מתנדבת<br>
POST <a href="http://leyadech.co.il/volunteers">http://leyadech.co.il/volunteers</a><br>
•	עדכון מתנדבת<br>
PUT <a href="http://leyadech.co.il/volunteers/1">http://leyadech.co.il/volunteers/1</a><br>
•	עדכון סטטוס מתנדבת<br>
PUT <a href="http://leyadech.co.il/volunteers/1/status">http://leyadech.co.il/volunteers/1/status</a><br>
•	שליפת רשימת ההתנדבויות של מתנדבת לפי מזהה<br>
GET <a href="http://leyadech.co.il/volunteers/1/volunteerings">http://leyadech.co.il/volunteers/1/volunteerings</a></p>
<p><strong>מיפוי שדות לבקשת סיוע</strong><br>
•	מזהה בקשה<br>
•	מזהה יולדת<br>
•	סוג סיוע נדרש<br>
•	תיאור הבקשה<br>
•	תאריך הגשת הבקשה<br>
•	תאריך התחלת סיוע<br>
•	תאריך סיום סיוע<br>
•	שעת התחלת סיוע<br>
•	שעת סיום סיוע<br>
•	תדירות<br>
•	דירוג רמת דחיפות<br>
•	רשימת העדפות</p>
<p><strong>מיפוי Routes לבקשת סיוע</strong><br>
•	שליפת כל הבקשות הרלוונטיות<br>
GET <a href="http://leyadech.co.il/requests">http://leyadech.co.il/requests</a><br>
•	שליפת בקשה לפי מזהה<br>
GET <a href="http://leyadech.co.il/requests/1">http://leyadech.co.il/requests/1</a><br>
•	עדכון בקשה<br>
PUT <a href="http://leyadech.co.il/requests/1">http://leyadech.co.il/requests/1</a><br>
•	הוספת בקשה<br>
POST <a href="http://leyadech.co.il/requests">http://leyadech.co.il/requests</a><br>
•	מחיקת בקשה<br>
DELETE <a href="http://leyadech.co.il/requests/1">http://leyadech.co.il/requests/1</a></p>
<p>•	שליפת כל בקשות הסיוע לפי מזהה יולדת<br>
GET <a href="http://leyadech.co.il/requests/?mother=1">http://leyadech.co.il/requests/?mother=1</a></p>
<p><strong>מיפוי שדות להצעת עזרה</strong><br>
•	מזהה הצעה<br>
•	מזהה מתנדבת<br>
•	סוג סיוע<br>
•	תיאור<br>
•	תאריך הגשת הצעה<br>
•	תאריך התחלת סיוע<br>
•	תאריך סיום סיוע<br>
•	שעת התחלת סיוע<br>
•	שעת סיום סיוע<br>
•	גמיש (כן/לא)<br>
•	תדירות<br>
•	רשימת ימים בשבוע פנויים לסיוע</p>
<p><strong>מיפוי Routes להצעת עזרה</strong><br>
•	שליפת כל ההצעות<br>
GET <a href="http://leyadech.co.il/suggests">http://leyadech.co.il/suggests</a><br>
•	שליפת הצעה לפי מזהה<br>
GET <a href="http://leyadech.co.il/suggests/1">http://leyadech.co.il/suggests/1</a><br>
•	הוספת הצעה<br>
POST <a href="http://leyadech.co.il/suggests">http://leyadech.co.il/suggests</a><br>
•	עדכון הצעה<br>
PUT <a href="http://leyadech.co.il/suggests/1">http://leyadech.co.il/suggests/1</a><br>
•	מחיקת הצעה<br>
DELETE <a href="http://leyadech.co.il/suggests/1">http://leyadech.co.il/suggests/1</a><br>
•	שליפת כל ההצעות לפי מזהה מתנדבת<br>
GET <a href="http://leyadech.co.il/suggests/?volunteer=1">http://leyadech.co.il/suggests/?volunteer=1</a></p>
<p><strong>מיפוי שדות להתנדבות</strong><br>
•	מזהה התנדבות<br>
•	מזהה בקשה<br>
•	מזהה הצעה<br>
•	תיאור<br>
•	סוג סיוע<br>
•	תדירות -enum<br>
•	מזהה יולדת<br>
•	מזהה מתנדבת<br>
•	תאריך התחלת התנדבות<br>
•	תאריך סיום התנדבות<br>
•	שעת התחלת התנדבות<br>
•	שעת סיום התנדבות<br>
•	דירוג רמת שביעות רצון<br>
•	משוב למתנדבת</p>
<p><strong>מיפוי Routes להתנדבות</strong><br>
•	שליפת כל ההתנדבויות<br>
GET <a href="http://leyadech.co.il/volunteerings">http://leyadech.co.il/volunteerings</a><br>
•	שליפת התנדבות לפי מזהה<br>
GET <a href="http://leyadech.co.il/volunteerings/1">http://leyadech.co.il/volunteerings/1</a><br>
•	הוספת התנדבות<br>
POST <a href="http://leyadech.co.il/volunteerings">http://leyadech.co.il/volunteerings</a><br>
•	עדכון התנדבות<br>
PUT <a href="http://leyadech.co.il/volunteerings/1">http://leyadech.co.il/volunteerings/1</a><br>
•	מחיקת התנדבות<br>
DELETE <a href="http://leyadech.co.il/volunteerings/1">http://leyadech.co.il/volunteerings/1</a><br>
•	דירוג רמת שביעות רצון והוספת משוב למתנדבת<br>
PUT <a href="http://leyadech.co.il/volunteerings/1/feedback">http://leyadech.co.il/volunteerings/1/feedback</a></p>
<blockquote>
<p>Written with <a href="https://stackedit.io/">StackEdit</a>.</p>
</blockquote>

