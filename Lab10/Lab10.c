#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <locale.h>
#include <ctype.h>
#pragma warning(disable : 4996)

int main(void)
{
	system("chcp 1251"); //Встановив кодування
	setlocale(LC_CTYPE, "ukr"); //Підключив мову.
	system("cls");

	int n = 80;
	char* str = (char*)calloc(n, sizeof(char*));

	printf("Задайте рядок:\n");
	gets(str);

	n = strlen(str) + 1;
	str = (char*)realloc(str, n * sizeof(char*)); //Перевиділення памяті на довжину строки
	char* words_small_5 = (char*)calloc(n, sizeof(char*));
	char* buff = (char*)calloc(n, sizeof(char*));

	int p = 0, sum_gol = 0;
	for (int i = 0; i <= n; i++) {
		if (str[i] == ' ' || str[i] == '\0' || str[i] == ',' || str[i] == '.') {
			for (int j = 0; j < i - p; j++) { //заповнення буферного масиву
				buff[j] = str[j + p];
			}

			if (buff[i - p - 1] == 'а' || buff[i - p - 1] == 'А' || buff[i - p - 1] == 'е' || buff[i - p - 1] == 'Е' || buff[i - p - 1] == 'є' || buff[i - p - 1] == 'Є' || buff[i - p - 1] == 'и' || buff[i - p - 1] == 'И' || buff[i - p - 1] == 'і' || buff[i - p - 1] == 'І' || buff[i - p - 1] == 'ї' || buff[i - p - 1] == 'Ї' || buff[i - p - 1] == 'о' || buff[i - p - 1] == 'О' || buff[i - p - 1] == 'у' || buff[i - p - 1] == 'У' || buff[i - p - 1] == 'ю' || buff[i - p - 1] == 'Ю' || buff[i - p - 1] == 'я' || buff[i - p - 1] == 'Я') {
				sum_gol++;
			}

			if (strlen(buff) < 5) {
				strcat(words_small_5, buff);
				strcat(words_small_5, " ");
			}

			for (int j = 0; j <= 40; j++) //очищення 
				buff[j] = 0;
			p = i + 1;
		}
	}

	printf("\nКількість слів у тексті, які закінчуються на голосну літеру:\n");
	printf("\t%d", sum_gol);

	printf("\nВсі слова, довжина яких менша п'яти символів\n");
	printf("\t"); puts(words_small_5);

	free(str);
	free(words_small_5);
	free(buff);

}