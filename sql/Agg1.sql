select Full_time, max(LASTNUM)as High, sum(VOL) as Vol from MAIN
group by FULL_TIME
order by FULL_TIME
