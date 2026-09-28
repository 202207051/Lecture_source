#include <stdio.h>
#include <stdlib.h>

// [실행을 위한 필수 정의] 노드 및 헤드 구조체
typedef struct ListNode {
    float coef;
    int expo;
    struct ListNode* link;
} ListNode;

typedef struct ListHead {
    ListNode* head;
} ListHead;


// ============================================================
// [사진 1] 공백 다항식 리스트 생성 및 노드 추가 연산
// ============================================================
// 공백 다항식 리스트를 생성하는 연산
ListHead* createLinkedList(void) {
    ListHead* L;
    L = (ListHead*)malloc(sizeof(ListHead));
    L->head = NULL;
    return L;
}

// 다항식 리스트에 마지막 노드를 추가하는 연산
void appendTerm(ListHead* L, float coef, int expo) {
    ListNode* newNode;
    ListNode* p;
    newNode = (ListNode*)malloc(sizeof(ListNode));
    newNode->coef = coef;
    newNode->expo = expo;
    newNode->link = NULL;

    if (L->head == NULL) {       // 다항식 리스트가 공백인 경우
        L->head = newNode;
        return;
    }
    else {                      // 다항식 리스트가 공백이 아닌 경우
        p = L->head;
        while (p->link != NULL) {
            p = p->link;        // 리스트의 마지막 노드를 찾음
        }
        p->link = newNode;      // 새 노드 연결
    }
}


// ============================================================
// [사진 2] 다항식 리스트 출력 연산
// ============================================================
// 다항식 리스트를 출력하는 연산
void printPoly(ListHead* L) {
    ListNode* p = L->head;
    for (; p; p = p->link) {
        printf("%3.0fx^%d", p->coef, p->expo);
        if (p->link != NULL) printf(" +");
    }
}


// ============================================================
// [사진 3] 두 다항식의 덧셈 연산
// ============================================================
// 두 다항식의 덧셈을 구하는 연산
void addPoly(ListHead* A, ListHead* B, ListHead* C) {
    ListNode* pA = A->head;
    ListNode* pB = B->head;
    float sum;

    // 두 다항식에 노드가 있는 동안 반복 수행
    while (pA && pB) {
        // 다항식 A의 지수가 다항식 B의 지수와 같은 경우
        if (pA->expo == pB->expo) {
            sum = pA->coef + pB->coef;
            appendTerm(C, sum, pA->expo);
            pA = pA->link; pB = pB->link;
        }
        // 다항식 A의 지수가 다항식 B의 지수보다 큰 경우
        else if (pA->expo > pB->expo) {
            appendTerm(C, pA->coef, pA->expo);
            pA = pA->link;
        }
        // 다항식 A의 지수가 다항식 B의 지수보다 작은 경우
        else {
            appendTerm(C, pB->coef, pB->expo);
            pB = pB->link;
        }
    }
    // 다항식 A에 남아 있는 노드 복사
    for (; pA != NULL; pA = pA->link)
        appendTerm(C, pA->coef, pA->expo);

    // 다항식 B에 남아 있는 노드 복사
    for (; pB != NULL; pB = pB->link)
        appendTerm(C, pB->coef, pB->expo);
}


// ============================================================
// [실행을 위한 필수 정의] main 함수
// ============================================================
int main(void) {
    ListHead* A, * B, * C;

    // 1. 리스트 생성
    A = createLinkedList();
    B = createLinkedList();
    C = createLinkedList();

    // 2. 다항식 A 추가 (4x^3 + 3x^2 + 5x^0)
    appendTerm(A, 4, 3);
    appendTerm(A, 3, 2);
    appendTerm(A, 5, 0);

    // 3. 다항식 B 추가 (3x^4 + 1x^3 + 2x^1 + 1x^0)
    appendTerm(B, 3, 4);
    appendTerm(B, 1, 3);
    appendTerm(B, 2, 1);
    appendTerm(B, 1, 0);

    // 4. 다항식 출력 및 덧셈 연산 실행
    printf("A(x) = ");
    printPoly(A);
    printf("\n");

    printf("B(x) = ");
    printPoly(B);
    printf("\n");

    addPoly(A, B, C);

    printf("C(x) = ");
    printPoly(C);
    printf("\n");

    return 0;
}