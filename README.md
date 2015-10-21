# AutoPlay
AutoPlay is a shared project provided with a sample Universal Windows App which reduces Product Designers’ workload by automatically generating multilingual screenshots.
Use cases and mocked data can be easily configured (example below).

```xml
<Script>
  <LanguageSettings>
    <Language Key="en-US">
      <Page2 Text="John" />
    </Language>
    <Language Key="de">
      <Page2 Text="Herman" />
    </Language>
    <Language Key="fr">
      <Page2 Text="Agnés" />
    </Language>
  </LanguageSettings>
  <PageProtocol>
    <Page Name="Page1" />
    <Page Name="Page2" Action="FocusSearch" />
    <Page Name="Page2" Action="SetSearchText" />
    <Page Name="Page2" Action="UnfocusSearch" />
    <Page Name="Page3" />
  </PageProtocol>
</Script>
```
