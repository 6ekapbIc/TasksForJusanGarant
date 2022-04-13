--------------------------Task 2.1-------------------------
SELECT C.NAME,M.NAME FROM ORDERS O
INNER JOIN CUSTOMERS C ON C.ID = O.CUSTOMER_ID
INNER JOIN MANAGERS M ON M.ID = C.ID
WHERE O.DATE > '01.01.2013'
GROUP BY C.NAME,M.NAME
HAVING SUM(AMOUNT) > 10000 
-----------------------------------------------------------

--------------------------Task 2.2-------------------------
-- В задании не было названия таблицы из-за чего я это таблицу
-- назвал employees
--------------------------Task 2.2.1-----------------------
SELECT * FROM EMPLOYEES E WHERE E.NAME LIKE '%m%'
-----------------------------------------------------------
--------------------------Task 2.2.2-----------------------
SELECT MAX(SALARY), DEPT_ID FROM EMPLOYEES E 
GROUP BY DEPT_ID
-----------------------------------------------------------
--------------------------Task 2.2.3-----------------------
SELECT * FROM EMPLOYEES
WHERE SALARY IN 
(SELECT SALARY FROM EMPLOYEES GROUP BY SALARY
HAVING COUNT(*) > 1)
-----------------------------------------------------------
-----------------------------------------------------------