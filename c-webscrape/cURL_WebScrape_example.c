#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <ctype.h>
#include <curl/curl.h>

void fetch_web_data(struct web_data *chunk, char *address);
static size_t write_mem(void *contents, size_t size, size_t n, void *userp);

#define ID 6
#define SPEED 8
#define TIMETRAVEL 9
#define STATUS 20
#define DATE 19
#define LINKID 10
#define LINKPOINT 258
#define ENCODE 258
#define POLYLINE 67
#define OWNER 27
#define TRANS 10
#define BOROUGH 16
#define LINKNAME 80
struct chunk
{

	char data[140];
	struct chunk * next;
};

struct node {

	char id[ID];
	char speed[SPEED];
	char travelTime[TIMETRAVEL];
	char status[STATUS];
	char dataAsOf[DATE];
	char linkId[LINKID];
	char linkpoints[LINKPOINT];
	char encoded[ENCODE];
	char polyline[POLYLINE];
	char owner[OWNER];
	char trans[TRANS];
	char borough[BOROUGH];
	char linkName[LINKNAME];
	struct node *next;
};

// Define our struct for accepting LCs output
struct web_data {
	char *buffer;
	size_t size;
};



#define TSIZE 280

int main()
{
	struct web_data someLink;
	//long bytes_read;
	char camLink[] = "http://207.251.86.229/nyc-links-cams/LinkSpeedQuery.txt";
	fetch_web_data(&someLink, camLink);
	char mytemp[TSIZE];
	struct node *setNode, *head;
	char *myptr = mytemp;
	setNode = (struct node *)malloc(sizeof(*setNode));
	head = setNode;


	someLink.buffer += 150;


	int count = 0;
	for (int j = 0; j < 150; j++) {

		char *p[] = { setNode->id, setNode->speed, setNode->travelTime, setNode->status,
			setNode->dataAsOf, setNode->linkId, setNode->linkpoints, setNode->encoded,
			setNode->polyline, setNode->owner, setNode->trans, setNode->borough, setNode->linkName };


		while (count < 13) {
			while (*someLink.buffer != '\"') { someLink.buffer++; }
			if (*someLink.buffer == '\"') {
				++someLink.buffer; while (*someLink.buffer != '\"') { *myptr++ = *someLink.buffer++; }
				*myptr = '\0'; strcpy(p[count], mytemp); memset(&mytemp[count], 0, sizeof(mytemp)); myptr = mytemp; count++;
			}   ++someLink.buffer;
		}count = 0;


		setNode->next = (struct node *)malloc(sizeof(*setNode));
		setNode = setNode->next;

	}

	setNode->next = head;
	head = setNode;
	setNode = setNode->next;
	free(head);

	int f = 0;
	while (f < 100) {

		printf("\nID:%s\tSpeed:%smph\tTime:%s\tLocation:%s", setNode->id, setNode->speed, setNode->dataAsOf, setNode->borough);
		setNode = setNode->next;
		f++;
	}



	//printf("%d",bytes_read);




	return 0;
}


void buildList(struct web_data *my) {

}


// This is the function we pass to LC, which writes the output to a BufferStruct
void fetch_web_data(struct web_data *chunk, char *address)
{
	CURL *curl;
	CURLcode res;// We’ll store the result of CURL’s webpage retrieval, for simple error checking.

				 /* will be grown as needed by the realloc above */
	chunk->buffer = malloc(1);
	/* no data at this point */
	chunk->size = 0;

	curl_global_init(CURL_GLOBAL_ALL);
	/* init the curl session */
	curl = curl_easy_init();
	if (!curl)
	{
		fprintf(stderr, "Unable to initialize curl.\n");
		exit(1);
	}


	/* configure libcurl to read and store the information */

	/* specify URL to get */
	curl_easy_setopt(curl, CURLOPT_URL, address);
	/* example.com is redirected, so we tell libcurl to follow redirection */
	curl_easy_setopt(curl, CURLOPT_FOLLOWLOCATION, 1L);
	/* send all data to this function  */
	curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, write_mem);
	/* we pass our 'chunk' struct to the callback function */
	curl_easy_setopt(curl, CURLOPT_WRITEDATA, (void *)chunk);
	/* some servers don't like requests that are made without a user-agent
	field, so we provide one */
	curl_easy_setopt(curl, CURLOPT_USERAGENT, "libcurl-agent/1.0");
	/*performs the entire request in a blocking manner and returns when done, or if it failed*/
	res = curl_easy_perform(curl);

	/* check for errors */
	if (res != CURLE_OK)
	{
		fprintf(stderr, "curl failed: %s\n", curl_easy_strerror(res));
		exit(1);
	}


	/* cleanup curl stuff */
	curl_easy_cleanup(curl);

	//return((long)chunk->size);

}

static size_t write_mem(void *ptr, size_t size, size_t nmemb, void *userdata)
{
	size_t realsize;
	struct web_data *mem;

	realsize = size * nmemb;
	mem = (struct web_data *)userdata;

	/* re-size the input buffer to accomodate the information read */
	mem->buffer = realloc(mem->buffer, mem->size + realsize + 1);
	if (mem->buffer == NULL)
	{
		/* out of memory! */
		fprintf(stderr, "Unable to allocate buffer for web page storage.\n");
		exit(1);
	}

	memcpy(&(mem->buffer[mem->size]), ptr, realsize);
	mem->size += realsize;
	mem->buffer[mem->size] = 0;

	return(realsize);
}

