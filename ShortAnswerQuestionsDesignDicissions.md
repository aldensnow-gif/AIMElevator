
# Short Answer Question Dicisions

## Platform, Infrastructure, and Container aaS(As a servvice) 
### Cloud service comparison

#### PaaS (Platform as a Service)
-   Highest abstraction: serverless functions and logic apps.
-   Security, patching, and scaling handled by the provider.
-   Flexible for rapid deployment but limited in customization.
-   Pricing can be lower due to granular scaling, though unpredictable.
-   Portability between vendors is limited.
#### IaaS (Infrastructure as a Service)
-   Lowest abstraction: virtual machines and networks.
-   User responsible for OS patching, scaling, and configuration.
-   Pricing is more consistent but often higher due to less granular scaling.
-   Typically provisioned for peak demand; scaling is reactive or planned.
-   Highly portable across vendors and replicable on-premises.
#### CaaS (Containers as a Service)
-   Container platforms (e.g., Docker, Kubernetes/AKS).
-   Users manage OS patching and scaling policies.
-   Multiple containers share resources; autoscaling based on demand.
-   Pricing is steadier than PaaS but less granular.
-   Portable across vendors and local hardware, though

## General-Purpose Clouds

These providers serve a wide range of industries and support diverse workloads.

### Azure

-   Strong integration with Microsoft tools and licenses.
-   Wizard-driven configuration makes setup more approachable.
-   Licensing costs can make it more expensive than competitors.

### AWS (Amazon Web Services)

-   Largest market share and broadest service catalog.
-   Extensive documentation and strong community support.
-   Pricing can be competitive, though complexity adds overhead.

### GCP (Google Cloud Platform)

-   Positioned between AWS and Azure in cost and complexity.
-   Strong in data analytics, AI/ML, and Kubernetes support.
-   Less widely adopted than AWS or Azure.

## Purpose-Built Cloud Providers

These offerings specialize in specific domains rather than broad workloads.

-   ### Salesforce

-   Focused on CRM and customer data management.
-   Provides a proprietary ecosystem for sales and marketing applications.

-   ### NVIDIA

-   Specializes in AI, machine learning, and GPU workloads.
-   Strong support for high performance computing.

-   ### Cisco

-   Enterprise-focused, emphasizing networking, security, and infrastructure solutions.
-   Often hybrid with onpremnetworking appliances

## Build vs. Buy

-   Architects and engineers regularly weigh whether to build or buy software — at project start and throughout product evolution.
-   Core question: does the software differentiate the business, or simply support industry best practices?
-   Common example: Accounting and HR ERP systems are typically purchased, since they are standard across industries.
-   **Advantages of buying**: saves effort, avoids reinventing common systems.
-   **Challenges**: limited customization, dependent on vendor release schedules.
-   Similar tradeoffs exist for other systems: purchased solutions may cover most needs, but custom builds allow differentiation where off-the-shelf tools fall short.

Serverless Architecture

-   Often the most economical option, depending on vendor scaling efficiency.
-   Infrastructure concerns (security, scaling, patching) are abstracted away.
-   Developers focus on business logic rather than infrastructure.
-   Cost savings come from efficient hardware utilization by vendors.
-   Drawback: strong vendor lock-in.
## Composition Over Inheritance
Composition over Inheritance means assembling classes from smaller, reusable components with specific responsibilities, rather than extending behavior through inheritance hierarchies
This project explored a contract-first approach using OpenAPI, NSwag, and related tooling to design the API schema and generate controller interfaces and models directly from the contract.

While this approach can work well in mature environments, in practice the available generation tools proved insufficiently stable for this scope, even with a relatively simple schema. Generated controllers and models frequently required manual modification to function correctly or to align with project conventions, which reduced the practical value of code generation.

In particular, the generated output tended to rely heavily on inheritance-based patterns, making it difficult to cleanly separate:

dynamically generated code that changes as the contract evolves, and

handwritten controller logic that should remain stable.

Without a clear composition-over-inheritance model to isolate generated artifacts from application logic, contract updates risked cascading changes across controllers, undermining SOLID principles and increasing maintenance overhead.

Contract-first workflows can be highly effective when these patterns have been well-established and tooling has been standardized. However, for the scope of this exercise, the additional complexity and ongoing customization required did not justify the investment. The project therefore favors explicit controller definitions with Swagger-first documentation, preserving clarity, stability, and maintainability while still exposing a complete OpenAPI contract for consumers.

Although this project does not rely on generated controller interfaces, the resulting controller design remains SOLID-aligned. The API contract is still expressed in a single, well-defined place through shared request and response models, and those models are reused consistently across endpoints.

Changes to the contract are therefore localized and explicit, rather than being distributed across generated and handwritten code. This preserves the benefits of clarity and maintainability without introducing tightly coupled inheritance hierarchies or fragile regeneration workflows.

By favoring explicit controller actions backed by shared models, the implementation maintains:

a clear separation of concerns,

a single source of truth for request and response shapes, and

predictable evolution of the API surface as requirements change.

This approach trades automated controller generation for intentional, readable API code, while still producing a complete and accurate OpenAPI contract for documentation, testing, and client generation.


## Previously Used Design Pattern
I applied the Strangler Pattern, incrementally replacing a legacy website by rewriting its components as microservices with the goal of eventually retiring the old page.
Ultimately, this approach created technical debt that was difficult to manage. Once the microservices were running, there was less urgency to migrate the hosting page to newer frameworks. As a result, older code persisted longer than expected, and in hindsight a full rewrite might have eliminated the legacy code faster and more cleanly.