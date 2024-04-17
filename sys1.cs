/*
 
Scalability
    -   system’s ability to handle increased load
    -   2 types :   
            horizontal (adding more machines to a system) scaling
            vertical scaling (increasing the resources of an existing machine)

Reliability
    -   measure of a system’s ability to function correctly and consistently, 
        even in the presence of failures or errors
    -   means - fault-tolerant, meaning it can detect and recover from failures 
        without significant impact on users.
    -   achieve this through redundancy, error handling, and monitoring.

Availability
    -   High availability is achieved by minimizing downtime, 
        using techniques such as redundancy, load balancing, and failover mechanisms.

Consistency
    -   ensures all parts of a distributed system provide the same view of data at any given time
    
Components of a Distributed System
    
    -   Domain Name System
        -   translates human-friendly domain names into their corresponding IP addresses
    -   Load Balancers
        -   distribute incoming network traffic across multiple servers to ensure optimal resource utilization
    -   Databases   
    -   Caches
        -   temporary storage systems that store frequently accessed data
            strategies Least Recently Used (LRU) and Time-To-Live (TTL),
    -   Message Queues
        -   asynchronous communication between different parts of the system
        -   Message queues help improve system reliability, fault tolerance, and scalability by allowing 
            components to work independently and manage fluctuations in workload
    -   Data Storage Systems
        -   persisting and managing data in distributed systems
    -   CDN
        -   is a distributed network of servers that store and deliver content, such as images, videos, 
            stylesheets, and scripts, to users from geographically closer locations
    -   Forward Proxy vs. Reverse Proxy
        -   sits in front of one or more client machines and acts 
            as an intermediary between the clients and the interne






 */ 