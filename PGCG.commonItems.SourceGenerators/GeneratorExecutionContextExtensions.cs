using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

#nullable enable
namespace commonItems.SourceGenerators {
    public static class GeneratorExecutionContextExtensions {
        private static readonly DiagnosticDescriptor MissingPartialModifier = new DiagnosticDescriptor(
            id: "PGCG001",
            title: "Missing partial modifier",
            messageFormat: "A partial modifier is required, Serialize method implementation will not be generated",
            category: "commonItems.SourceGenerators",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public static void ReportMissingPartialModifier(
            this SourceProductionContext context,  // Use SourceProductionContext instead
            ClassDeclarationSyntax classDeclaration)
            => context.ReportDiagnostic(
                Diagnostic.Create(
                    MissingPartialModifier,
                    classDeclaration.GetLocation(),
                    classDeclaration.Identifier.Text));
    }
}